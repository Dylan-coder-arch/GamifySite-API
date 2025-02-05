using GamifySite_API.DTO.VoucherDetailsDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.VoucherDetailMapper;
using GamifySite_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherDetailsController : ControllerBase
    {
        private readonly IVoucherDetailRepository _voucherDetailRepo;
        public VoucherDetailsController(IVoucherDetailRepository vouchRepo)
        {
            _voucherDetailRepo = vouchRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var vDetails = await _voucherDetailRepo.GetAllAsync();
            var vDetailObj = vDetails.Select(vd => vd.ToVoucherDetailDTO()).ToList();
            return Ok(vDetailObj);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {

            var vDetail = await _voucherDetailRepo.GetByIdAsync(id);

            if (vDetail == null)
            {
                return NotFound();
            }


            return Ok(vDetail.ToVoucherDetailDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var vDetailDelete = await _voucherDetailRepo.DeleteAsync(id);
            if (vDetailDelete == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateVoucherDetailsRequestDTO requestDTO)
        {
            var toVoucher = requestDTO.ToVoucherDetailFromCreate();
            var createdVoucher = await _voucherDetailRepo.CreateVoucherDetailAsync(toVoucher);
            return Ok(createdVoucher.ToVoucherDetailDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateVoucherDetailRequestDTO vouchUpdate)
        {
            var vDetail = new VoucherDetail
            {
                VoucherDetailID = id,
                VoucherCode = vouchUpdate.VoucherCode,
                VoucherCodeStatus = vouchUpdate.VoucherCodeStatus,
                UserID = vouchUpdate.UserID,
                ClaimedTime = vouchUpdate.ClaimedTime,
                VoucherID = vouchUpdate.VoucherID
            };

            var updatedVoucherDetail = await _voucherDetailRepo.UpdateVoucherDetailAsync(id, vDetail);
            if (updatedVoucherDetail == null)
            {
                return NotFound();
            }
            return Ok(updatedVoucherDetail.ToVoucherDetailDTO());
        }
    }
}
