using GamifySite_API.DTO.RatingDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.RatingMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingsController : ControllerBase
    {
        private readonly IRatingRepository _ratingRepo;
        private readonly IVoucherRepository _voucherRepo;
        public RatingsController(IRatingRepository ratingRepo, IVoucherRepository voucherRepo) 
        {
            _ratingRepo = ratingRepo;
            _voucherRepo = voucherRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var ratings = await _ratingRepo.GetAllAsync();
            var ratingDto = ratings.Select(s => s.ToRatingDto()).ToList(); 

            return Ok(ratingDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var rating = await _ratingRepo.GetByIDAsync(id);
            if (rating == null)
            {

                return NotFound();
            }
            var ratingDto = rating.ToRatingDto();
            return Ok(ratingDto);
        }

        [HttpPost("{voucherID}")]
        public async Task<IActionResult> Create([FromRoute] Guid voucherID, [FromBody] CreateRatingRequestDTO ratingRequest)
        {
           if (!await _voucherRepo.VoucherExists(voucherID))
           {
                return BadRequest("Voucher does not exist!");
           } 

           var ratingModel = ratingRequest.ToRatingFromCreateDto(voucherID);
           await _ratingRepo.CreateAsync(ratingModel);
           return CreatedAtAction(nameof(GetByID), new { id = ratingModel.RatingID }, ratingModel.ToRatingDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid ratingID, [FromBody] UpdateRatingRequestDTO ratingRequest)
        {
            var ratingModel = await _ratingRepo.UpdateAsync(ratingID, ratingRequest);
            if (ratingModel == null)
            {
                return NotFound();
            }
            return Ok(ratingModel.ToRatingDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var ratingDelete = await _ratingRepo.DeleteAsync(id);
            if (ratingDelete == null)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
