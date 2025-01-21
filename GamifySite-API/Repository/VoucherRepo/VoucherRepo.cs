using GamifySite_API.DBContext;
using GamifySite_API.DTO.VoucherDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.VoucherRepo
{
    public class VoucherRepo : IVoucherRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public VoucherRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Voucher> CreateAsync(Voucher voucherModel)
        {
            await _dbContext.Vouchers.AddAsync(voucherModel);
            await _dbContext.SaveChangesAsync();
            return voucherModel;
        }

        public async Task<Voucher?> DeleteAsync(Guid id)
        {
            var voucherModel = await _dbContext.Vouchers.FirstOrDefaultAsync(x => x.VoucherID == id);
            if (voucherModel == null)
            {
                return null;
            }
            _dbContext.Vouchers.Remove(voucherModel);
            await _dbContext.SaveChangesAsync();
            return voucherModel;
        }

        public Task<bool> VoucherExists(Guid id)
        {
            return _dbContext.Vouchers.AnyAsync(s => s.VoucherID == id);
        }

        public async Task<List<Voucher>> GetAllAsync()
        {
            return await _dbContext.Vouchers.Include(r => r.Ratings).ToListAsync();
        }

        
        public async Task<Voucher?> GetByIDAsync(Guid id)
        {
            return await _dbContext.Vouchers.Include(r => r.Ratings).FirstOrDefaultAsync(x => x.VoucherID == id);
        }

        public async Task<Voucher?> UpdateAsync(Guid id, UpdateVoucherRequestDTO updateReq)
        {
            var voucherModel = await _dbContext.Vouchers.FirstOrDefaultAsync(x => x.VoucherID == id);
            if (voucherModel == null)
            {
                return null;
            }

            voucherModel.VoucherStatus = updateReq.VoucherStatus;
            voucherModel.VoucherAmount = updateReq.VoucherAmount;
            voucherModel.VoucherLocation = updateReq.VoucherLocation;
            voucherModel.VoucherExpiry = updateReq.VoucherExpiry;
            voucherModel.VoucherName = updateReq.VoucherName;
            voucherModel.DateModified = DateTime.UtcNow;
            voucherModel.Special1 = updateReq.Special1;
            voucherModel.Special2 = updateReq.Special2;
            voucherModel.Special3 = updateReq.Special3;
            voucherModel.Visible = updateReq.Visible;
            voucherModel.Stock = updateReq.Stock;
            

            await _dbContext.SaveChangesAsync();

            return voucherModel;
        }


    }
}
