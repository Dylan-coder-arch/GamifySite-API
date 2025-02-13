using GamifySite_API.DTO.PaymentDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.PaymentMapper
{
    public static class PaymentMapper
    {


        public static PaymentDto ToPaymentDto(this Payment payment)
        {
            return new PaymentDto
            {
                PaymentID = payment.PaymentID,
                Amount = payment.Amount,
                PaymentTime = payment.PaymentTime,
                UserID = payment.UserID,
            };


        }

        public static Payment ToPaymentFromCreateDto(this CreatePaymentDto createPaymentDto)
        {
            return new Payment
            {
                PaymentTime = DateTime.UtcNow,
                Amount = createPaymentDto.Amount,
                UserID = createPaymentDto.UserID,
                PaymentID = Guid.NewGuid(),

            };
        }

    }
}
