using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.PaymentRepo
{
    public class PaymentRepo : IPaymentRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public PaymentRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Payment?> CreateAsync(Payment payment)
        {
            await _dbContext.Payments.AddAsync(payment);
            await _dbContext.SaveChangesAsync();
            return payment;
        }

        public async Task<Payment?> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Payment>> GetAllAsync()
        {
            return await _dbContext.Payments.ToListAsync();
        }

        public async Task<Payment?> GetByIdAsync(Guid id)
        {
            var payment = await _dbContext.Payments.FirstOrDefaultAsync(p => p.PaymentID == id);
            if (payment == null)
            {
                return null;
            }
            return payment;
        }
    }
}
