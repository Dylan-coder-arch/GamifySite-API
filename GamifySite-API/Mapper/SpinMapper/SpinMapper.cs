using GamifySite_API.DTO.SpinDTO;
using GamifySite_API.DTO.UserDTO;
using GamifySite_API.Mapper.SpinPrizeMapper;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.SpinMapper
{
    public static class SpinMapper
    {
        public static SpinDTO ToSpinDTO(this Spin spinModel) 
        {
            return new SpinDTO
            {
                SpinID = spinModel.SpinID,
                SpinName = spinModel.SpinName,  
                SpinPrizes = spinModel.SpinPrizes.Select(s => s.ToSpinPrizeDTO()).ToList(),
                DateCreated = spinModel.DateCreated,
            };
        }

        public static Spin ToSpinFromCreateDto(this CreateSpinRequestDTO createSpinRequestDTO)
        {
            return new Spin
            {
                DateCreated = DateTime.UtcNow,
                SpinName = createSpinRequestDTO.SpinName,
            };
        }

    }
}
