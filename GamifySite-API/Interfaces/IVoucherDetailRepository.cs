using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IVoucherDetailRepository
    {

        Task<List<VoucherDetail>> GetAllAsync();
        Task<VoucherDetail?> GetByIdAsync(Guid id);

        Task<VoucherDetail?> DeleteAsync(Guid id);
        Task<VoucherDetail?> UpdateVoucherDetailAsync(Guid id, VoucherDetail voucherDetail);
        Task<VoucherDetail> CreateVoucherDetailAsync(VoucherDetail voucherDetail);

    }
}
