using GamifySite_API.DTO.SpinDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface ISpinRepositry
    {

        Task<List<Spin>> GetAllAsync();
        Task<Spin?> GetByIDAsync(Guid id);
        Task<Spin?> DeleteAsync(Guid id);
        Task<Spin?> UpdateAsync(Guid id, UpdateSpinRequestDTO updateReq);
        Task<Spin> CreateAsync(Spin spinModel);

    }
}
