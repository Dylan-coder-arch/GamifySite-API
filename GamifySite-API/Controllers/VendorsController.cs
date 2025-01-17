using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GamifySite_API.DBContext;
using GamifySite_API.Models;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.VendorMapper;
using GamifySite_API.DTO.VendorDTO;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorRepository _vendorRepo;

        public VendorsController(IVendorRepository vendorRepo)
        {
            _vendorRepo = vendorRepo;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors()
        {
            var vendors = await _vendorRepo.GetAllAsync();
            var vendorDto = vendors.Select(s => s.ToVendorDto()).ToList();
            return Ok(vendorDto);
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(Guid id)
        {
            var vendor = await _vendorRepo.GetByIDAsync(id);

            if (vendor == null)
            {
                return NotFound();
            }

            return Ok(vendor.ToVendorDto());
        }

        // PUT: api/Vendors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor([FromRoute] Guid id, [FromBody] UpdateVendorRequestDTO vendor)
        {
            var vendorModel = await _vendorRepo.UpdateAsync(id, vendor);
            if (vendorModel == null)
            {
                return NotFound();
            }

            return Ok(vendorModel.ToVendorDto());
        }

        // POST: api/Vendors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor([FromBody] CreateVendorRequestDTO vendor)
        {
            var vendorModel = vendor.ToVendorFromCreate();
            await _vendorRepo.CreateAsync(vendorModel);

            return CreatedAtAction("GetVendor", new { id = vendorModel.VendorID }, vendorModel.ToVendorDto());
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(Guid id)
        {
            var vendorModel = await _vendorRepo.DeleteAsync(id);
            if (vendorModel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        private async Task<bool> VendorExists(Guid id)
        {
            return await _vendorRepo.Exists(id);
        }
    }
}
