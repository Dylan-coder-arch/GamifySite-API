namespace GamifySite_API.Models
{
    public class SpinPrize
    {
        public Guid SpinPrizeID { get; set; }
        public Guid SpinID { get; set; }
        public Guid VoucherID { get; set; }
        public decimal Probability { get; set; }

        public Spin Spin { get; set; }
        public Voucher Voucher { get; set; }

    }
}
