namespace GamifySite_API.Models
{
    public class Rating
    {
        public Guid RatingID { get; set; }
        public Guid VoucherID { get; set; }
        public Guid UserID { get; set; }
        public decimal RatingValue { get; set; }
        public string Comment { get; set; }

        public User User { get; set; }
        public Voucher Voucher { get; set; }

    }
}
