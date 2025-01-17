namespace GamifySite_API.Models
{
    public class Payment
    {
        public Guid PaymentID { get; set; }
        public Guid PaidBy { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentTime { get; set; }

        public User Payer { get; set; }


    }
}
