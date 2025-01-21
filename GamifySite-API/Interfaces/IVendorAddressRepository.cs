using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IVendorAddressRepository
    {

        Task<List<VendorAddress>> GetAllAsync(); 

    }
}
