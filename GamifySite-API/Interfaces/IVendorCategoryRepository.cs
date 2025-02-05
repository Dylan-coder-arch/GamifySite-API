using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IVendorCategoryRepository
    {
        Task<List<VendorCategory>> GetAllAsync();
        Task<VendorCategory?> GetByID(Guid id);
        Task<VendorCategory?> DeleteAsync(Guid id);
        Task<VendorCategory?> UpdateAsync(Guid id, VendorCategory v);
        Task<VendorCategory> CreateAsync(VendorCategory v); 

    }
}
