using GamifySite_API.DTO.VendorAddressDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.VendorAddressMapper;
using GamifySite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorAddressController : ControllerBase
    {
        private readonly IVendorAddressRepository _vendAddrRepo;
        public VendorAddressController(IVendorAddressRepository vendAddrRepo)
        {
            _vendAddrRepo = vendAddrRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vendAddrItems = await _vendAddrRepo.GetAllAsync();
            var vendObj = vendAddrItems.Select(va => va.ToVendorAddressDTO()).ToList();
            return Ok(vendObj);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var vendTh = await _vendAddrRepo.GetByIDAsync(id);
            if (vendTh == null)
            {
                return NotFound();
            }
            var vendObj = vendTh.ToVendorAddressDTO();
            return Ok(vendObj);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var vendAddrDel = await _vendAddrRepo.DeleteAsync(id);
            if (vendAddrDel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVendorAddressDTO createVendAddr)
        {
            var vendAddr = createVendAddr.ToVendorFromCreateDTO();
            await _vendAddrRepo.CreateAsync(vendAddr);
            return CreatedAtAction(nameof(GetByID), new { id = vendAddr.VendorAddressID }, vendAddr.ToVendorAddressDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateVendorAddressDTO updateVendAddr)
        {
            var vendAddr = new VendorAddress
            {
                VendorAddressID = id,
                City = updateVendAddr.City,
                Country = updateVendAddr.Country,
                State = updateVendAddr.State,
                PostalCode = updateVendAddr.PostalCode,
                StreetAddress = updateVendAddr.StreetAddress,
            };
            var vendUp = await _vendAddrRepo.UpdateAsync(id, vendAddr);
            if (vendUp == null)
            {
                return NotFound();
            }
            return Ok(vendUp.ToVendorAddressDTO());
        }
    }
}
