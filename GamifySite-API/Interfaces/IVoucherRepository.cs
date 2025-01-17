using GamifySite_API.DTO.VendorDTO;
using GamifySite_API.DTO.VoucherDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IVoucherRepository
    {
        Task<List<Voucher>> GetAllAsync();

        Task<Voucher?> GetByIDAsync(Guid id);

        Task<Voucher> CreateAsync(Voucher vendorModel);
        Task<Voucher?> UpdateAsync(Guid id, UpdateVoucherRequestDTO updateReq);
        Task<Voucher?> DeleteAsync(Guid id);

        Task<bool> Exists(Guid id);

        // need to be able to get the voucher by vendorID as well/vendor name maybe ? 

    }
}
