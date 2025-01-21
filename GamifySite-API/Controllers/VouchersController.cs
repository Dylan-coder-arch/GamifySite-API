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
using GamifySite_API.Mapper.VoucherMapper;
using GamifySite_API.DTO.VoucherDTO;
using GamifySite_API.Repository.VendorRepo;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherRepository _voucherRepo;

        public VouchersController(IVoucherRepository voucherRepo)
        {
            _voucherRepo = voucherRepo;
        }

        // GET: api/Vouchers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voucher>>> GetVouchers()
        {

            var vouchers = await _voucherRepo.GetAllAsync();
            var voucherModel = vouchers.Select(s => s.ToVoucherDTO()).ToList();

            return Ok(voucherModel);
        }

        // GET: api/Vouchers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voucher>> GetVoucher(Guid id)
        {
            var voucher = await _voucherRepo.GetByIDAsync(id);

            if (voucher == null)
            {
                return NotFound();
            }

            return Ok(voucher.ToVoucherDTO());
        }

        // PUT: api/Vouchers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoucher(Guid id, UpdateVoucherRequestDTO voucher)
        {

            var voucherModel = await _voucherRepo.UpdateAsync(id, voucher);

            if (voucherModel == null)
            {
                return NotFound();
            }

            return Ok(voucherModel.ToVoucherDTO());
        }

        // POST: api/Vouchers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voucher>> PostVoucher(CreateVoucherRequestDTO voucher)
        {
            var voucherModel = voucher.ToVoucherFromCreateDto();

            await _voucherRepo.CreateAsync(voucherModel);

            return CreatedAtAction("GetVoucher", new { id = voucherModel.VoucherID }, voucherModel.ToVoucherDTO());
        }

        // DELETE: api/Vouchers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoucher(Guid id)
        {
            var voucherModel = await _voucherRepo.DeleteAsync(id);
            if (voucherModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }



    }
}
