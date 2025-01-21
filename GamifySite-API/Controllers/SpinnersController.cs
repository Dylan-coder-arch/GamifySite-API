using GamifySite_API.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GamifySite_API.Mapper.SpinMapper;
using GamifySite_API.DTO.SpinDTO;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinnersController : ControllerBase
    {
        private readonly ISpinRepositry _spinRepo;
        public SpinnersController(ISpinRepositry spinRepo)
        {
            _spinRepo = spinRepo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {


            var spins = await _spinRepo.GetAllAsync();
            var spinModel = spins.Select(s => s.ToSpinDTO()).ToList();
            return Ok(spinModel);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID([FromRoute] Guid id)
        {
            var spin = await _spinRepo.GetByIDAsync(id);
            if (spin == null)
            {
                return NotFound();
            }

            return Ok(spin.ToSpinDTO());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateSpinRequestDTO createSpinModel)
        {
            var spinModel = createSpinModel.ToSpinFromCreateDto();

            await _spinRepo.CreateAsync(spinModel);

            return CreatedAtAction(nameof(GetByID), new { id = spinModel.SpinID }, spinModel.ToSpinDTO());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] Guid id, [FromBody] UpdateSpinRequestDTO updateSpinModel)
        {
            var spinEdit = await _spinRepo.UpdateAsync(id, updateSpinModel);

            if (spinEdit == null)
            {
                return NotFound();
            }

            return Ok(spinEdit);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] Guid id)
        {
            var spinDel = await _spinRepo.DeleteAsync(id);
            if (spinDel == null)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
