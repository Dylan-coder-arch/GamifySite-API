using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IVendorAddressRepository
    {

        Task<List<VendorAddress>> GetAllAsync();
        Task<VendorAddress?> GetByIDAsync(Guid id);
        Task<VendorAddress?> DeleteAsync(Guid id);
        Task<VendorAddress?> UpdateAsync(Guid id, VendorAddress value);
        Task<VendorAddress> CreateAsync(VendorAddress value); 

    }
}
