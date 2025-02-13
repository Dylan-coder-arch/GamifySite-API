using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IPaymentRepository
    {

        Task<List<Payment>> GetAllAsync();
        Task<Payment?> GetByIdAsync(Guid id);
        Task<Payment?> DeleteAsync(Guid id);
        
        Task<Payment?> CreateAsync(Payment payment);
    }
}
