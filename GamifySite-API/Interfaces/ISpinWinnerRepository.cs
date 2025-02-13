using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface ISpinWinnerRepository
    {

        Task<List<SpinWinner>> GetAllAsync();
        Task<SpinWinner?> GetByIDAsync(Guid id);
        Task<SpinWinner> CreateAsync(SpinWinner spinWinner);
        
    }
}
