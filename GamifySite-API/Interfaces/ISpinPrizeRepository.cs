using GamifySite_API.DTO.SpinDTO;
using GamifySite_API.DTO.SpinPrizeDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface ISpinPrizeRepository
    {
        Task<List<SpinPrize>> GetAllAsync();
        Task<SpinPrize?> GetByIDAsync(Guid id);
        Task<SpinPrize?> DeleteAsync(Guid id);
        Task<SpinPrize?> UpdateAsync(Guid id, UpdateSpinPrizeDTO updateReq);
        Task<SpinPrize> CreateAsync(SpinPrize spinModel);

    }
}
