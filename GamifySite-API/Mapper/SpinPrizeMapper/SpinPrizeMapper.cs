using GamifySite_API.DTO.SpinPrizeDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.SpinPrizeMapper
{
    public static class SpinPrizeMapper
    {

        public static SpinPrizeDto ToSpinPrizeDTO(this SpinPrize spinPrize)
        {
            return new SpinPrizeDto
            {
                Probability = spinPrize.Probability,
                SpinID = spinPrize.SpinID,
                SpinPrizeID = spinPrize.SpinPrizeID,
                VoucherID = spinPrize.VoucherID,
            };
        }

        public static SpinPrize ToSpinPrizeFromCreateDTO(this CreateSpinPrizeDTO createSpinPrizeDTO)
        {

            return new SpinPrize
            {
                SpinID = createSpinPrizeDTO.SpinID,
                Probability = createSpinPrizeDTO.Probability,
                VoucherID = createSpinPrizeDTO.VoucherID,
            };

        }

    }
}
