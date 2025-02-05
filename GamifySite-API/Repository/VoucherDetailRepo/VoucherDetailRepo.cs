using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.VoucherDetailRepo
{
    public class VoucherDetailRepo : IVoucherDetailRepository
    {
        private readonly ApplicationDBContext _context;

        public VoucherDetailRepo(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<VoucherDetail> CreateVoucherDetailAsync(VoucherDetail voucherDetail)
        {
            await _context.VouchersDetail.AddAsync(voucherDetail);
            await _context.SaveChangesAsync();
            return voucherDetail;
        }

        public async Task<VoucherDetail?> DeleteAsync(Guid id)
        {
            var vdExist = await _context.VouchersDetail.FirstOrDefaultAsync(vd => vd.VoucherDetailID == id);
            if (vdExist == null)
            {
                return null;
            }
            _context.VouchersDetail.Remove(vdExist);
            await _context.SaveChangesAsync();
            return vdExist;
        }

        public async Task<List<VoucherDetail>> GetAllAsync()
        {
            return await _context.VouchersDetail.ToListAsync();
        }

        public async Task<VoucherDetail?> GetByIdAsync(Guid id)
        {
            var voucherDetail = await _context.VouchersDetail.FirstOrDefaultAsync(vd => vd.VoucherDetailID == id);
            if (voucherDetail == null)
            {
                return null;
            }
            return voucherDetail;
        }

        public async Task<VoucherDetail?> UpdateVoucherDetailAsync(Guid id, VoucherDetail voucherDetail)
        {
            var vdExist = await _context.VouchersDetail.FirstOrDefaultAsync(vd => vd.VoucherDetailID==id);
            if (vdExist == null)
            {
                return null;

            }
            vdExist.VoucherCode = voucherDetail.VoucherCode;
            vdExist.VoucherCodeStatus = voucherDetail.VoucherCodeStatus;
            vdExist.UserID = voucherDetail.UserID;
            vdExist.ClaimedTime = voucherDetail.ClaimedTime;
            vdExist.VoucherID = voucherDetail.VoucherID;
            await _context.SaveChangesAsync();
            return vdExist;
        }
    }
}
