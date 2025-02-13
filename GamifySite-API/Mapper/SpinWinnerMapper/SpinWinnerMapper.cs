using GamifySite_API.DTO.SpinWinnerDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.SpinWinnerMapper
{
    public static class SpinWinnerMapper
    {

        public static SpinWinnerDto ToSpinWinnerDto(this SpinWinner spinWinner)
        {
            return new SpinWinnerDto
            {
                DateWon = spinWinner.DateWon,
                SpinPrizeID = spinWinner.SpinPrizeID,
                SpinWinnerID = spinWinner.SpinWinnerID,
                UserID = spinWinner.UserID
            };
        }

        public static SpinWinner ToSpinWinnerFromCreateDto(this CreateSpinWinnerDto spinWinner)
        {
            return new SpinWinner
            {
                DateWon = DateTime.UtcNow,
                UserID = spinWinner.UserID,
                SpinPrizeID = spinWinner.SpinPrizeID,
                SpinWinnerID = Guid.NewGuid(),
            };
        }

    }
}
