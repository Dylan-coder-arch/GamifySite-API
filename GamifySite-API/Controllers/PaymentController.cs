using GamifySite_API.DTO.PaymentDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Mapper.PaymentMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamifySite_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentRepository _paymentRepo;
        public PaymentController(IPaymentRepository paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        [HttpGet]
        public async Task<ActionResult<List<PaymentDto>>> GetAll()
        {
            var paymentList = await _paymentRepo.GetAllAsync();
            var paymentDtoList = paymentList.Select(p => p.ToPaymentDto()).ToList();
            return paymentDtoList;
        }

        [HttpGet("{id:guid}")]
        public async Task<PaymentDto?> GetById([FromRoute] Guid id)
        {
            var payment = await _paymentRepo.GetByIdAsync(id);
            if (payment == null)
            {
                return null;
            }
            return payment.ToPaymentDto();
        }

        [HttpPost]
        public async Task<PaymentDto> Create([FromBody] CreatePaymentDto createPayment)
        {
            var pay = createPayment.ToPaymentFromCreateDto();
            await _paymentRepo.CreateAsync(pay);
            return pay.ToPaymentDto();
        }

    }
}
