namespace GamifySite_API.DTO.SpinPrizeDTO
{
    public class CreateSpinPrizeDTO
    {
        public Guid SpinID { get; set; }
        public Guid VoucherID { get; set; }
        public decimal Probability { get; set; }

    }
}
