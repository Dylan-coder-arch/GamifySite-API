using GamifySite_API.DTO.SpinPrizeDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.SpinPrizeMapper;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinnersPrizeController : ControllerBase
    {
        private readonly ISpinPrizeRepository _spinPrizeRepo;
        public SpinnersPrizeController(ISpinPrizeRepository spinPrizeRepo) 
        { 
            _spinPrizeRepo = spinPrizeRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var spinPrize = await _spinPrizeRepo.GetAllAsync();
            var spinPrizeModel = spinPrize.Select(sp => sp.ToSpinPrizeDTO()).ToList();

            return Ok(spinPrizeModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var spinPrize = await _spinPrizeRepo.GetByIDAsync(id);
            if (spinPrize == null)
            {
                return NotFound();

            }
            return Ok(spinPrize.ToSpinPrizeDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateSpinPrizeDTO updatePrizeReq)
        {
            var spinPrize = await _spinPrizeRepo.UpdateAsync(id, updatePrizeReq);
            if (spinPrize == null)
            {
                return NotFound();
            }
            return Ok(spinPrize.ToSpinPrizeDTO());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {

            var spinDel = await _spinPrizeRepo.DeleteAsync(id);
            if (spinDel == null)
            {
                return NotFound();
            }

            return NoContent();

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSpinPrizeDTO createSpinPrize)
        {
            // remember to check if both the voucher and the spin exists 
            // then you can post it 

            var spinPr = createSpinPrize.ToSpinPrizeFromCreateDTO();

            await _spinPrizeRepo.CreateAsync(spinPr);

            return CreatedAtAction(nameof(GetByID), new { id = spinPr.SpinPrizeID }, spinPr.ToSpinPrizeDTO());

        }

    }
}
