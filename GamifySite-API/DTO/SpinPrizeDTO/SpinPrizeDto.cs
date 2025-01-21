using GamifySite_API.Models;

namespace GamifySite_API.DTO.SpinPrizeDTO
{
    public class SpinPrizeDto
    {
        public Guid SpinPrizeID { get; set; }
        public Guid SpinID { get; set; }
        public Guid VoucherID { get; set; } // VoucherDetailID is what this should be in future
        public decimal Probability { get; set; }

    }
}
