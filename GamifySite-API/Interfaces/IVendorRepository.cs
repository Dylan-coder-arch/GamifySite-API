using GamifySite_API.DTO.UserDTO;
using GamifySite_API.DTO.VendorDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IVendorRepository
    {

        Task<List<Vendor>> GetAllAsync();
        
        Task<Vendor?> GetByIDAsync(Guid id);
        
        Task<Vendor> CreateAsync(Vendor vendorModel);
        Task<Vendor?> UpdateAsync(Guid id, UpdateVendorRequestDTO updateReq);
        Task<Vendor?> DeleteAsync(Guid id);

        Task<bool> Exists(Guid id);
    }
}
