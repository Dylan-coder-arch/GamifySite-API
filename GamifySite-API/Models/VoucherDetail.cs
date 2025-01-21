namespace GamifySite_API.Models
{
    public class VoucherDetail
    {
        public Guid VoucherDetailID { get; set; }
        public string VoucherCode { get; set; } = string.Empty;
        public string VoucherCodeStatus { get; set; } = string.Empty;
        public Guid VoucherID { get; set; }
        public Guid? UserID { get; set; }
        public DateTime? ClaimedTime { get; set; }

        public User? ClaimedUser { get; set; }
        public Voucher Voucher { get; set; }
    }
}
