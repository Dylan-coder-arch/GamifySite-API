using GamifySite_API.Models;

namespace GamifySite_API.DTO.PaymentDTO
{
    public class PaymentDto
    {
        public Guid PaymentID { get; set; }
        public Guid UserID { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentTime { get; set; }


    }
}
