using GamifySite_API.DTO.SpinWinnerDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.SpinWinnerMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpinWinnerController : ControllerBase
    {
        private readonly ISpinWinnerRepository _spinWinnerRepo;
        public SpinWinnerController(ISpinWinnerRepository spinWinnerRepo) 
        { 
            _spinWinnerRepo = spinWinnerRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<SpinWinnerDto>>> GetAll()
        {
            var spinWin = await _spinWinnerRepo.GetAllAsync();
            var spinWinList = spinWin.Select(sw => sw.ToSpinWinnerDto()).ToList();
            return spinWinList;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SpinWinnerDto>?> GetByID([FromRoute] Guid id)
        {
            var spinWin = await _spinWinnerRepo.GetByIDAsync(id);
            if (spinWin == null)
            {
                return null;
            }
            return spinWin.ToSpinWinnerDto();
        }

        [HttpPost]
        public async Task<ActionResult<SpinWinnerDto>> Create([FromBody] CreateSpinWinnerDto createSpinWin)
        {
            var spinWin = createSpinWin.ToSpinWinnerFromCreateDto();
            await _spinWinnerRepo.CreateAsync(spinWin);
            return spinWin.ToSpinWinnerDto();
        }

    }
}
