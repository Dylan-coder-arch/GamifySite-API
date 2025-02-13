namespace GamifySite_API.DTO.PaymentDTO
{
    public class CreatePaymentDto
    {
        public Guid UserID { get; set; }
        public decimal Amount { get; set; }

    }
}
