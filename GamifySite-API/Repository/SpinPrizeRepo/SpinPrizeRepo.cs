using GamifySite_API.DBContext;
using GamifySite_API.DTO.SpinPrizeDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.SpinPrizeRepo
{
    public class SpinPrizeRepo : ISpinPrizeRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SpinPrizeRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SpinPrize> CreateAsync(SpinPrize spinModel)
        {
            await _dbContext.SpinnersPrize.AddAsync(spinModel);
            await _dbContext.SaveChangesAsync();
            return spinModel;
        }

        public async Task<SpinPrize?> DeleteAsync(Guid id)
        {
            var spinPrizeExist = await _dbContext.SpinnersPrize.FirstOrDefaultAsync(sp => sp.SpinPrizeID == id);
            if (spinPrizeExist == null)
            {
                return null;
            }

            _dbContext.SpinnersPrize.Remove(spinPrizeExist);
            await _dbContext.SaveChangesAsync();
            return spinPrizeExist;
        }

        public async Task<List<SpinPrize>> GetAllAsync()
        {
            return await _dbContext.SpinnersPrize.ToListAsync();
        }

        public async Task<SpinPrize?> GetByIDAsync(Guid id)
        {
            var spinPrizeExist = await _dbContext.SpinnersPrize.FirstOrDefaultAsync(sp => sp.SpinPrizeID == id);
            if (spinPrizeExist == null)
            {
                return null;
            }
            return spinPrizeExist;
        }

        public async Task<SpinPrize?> UpdateAsync(Guid id, UpdateSpinPrizeDTO updateReq)
        {
            var spinPrizeExist = await _dbContext.SpinnersPrize.FirstOrDefaultAsync(sp => sp.SpinPrizeID == id);
            if (spinPrizeExist == null)
            {
                return null;
            }

            spinPrizeExist.VoucherID = updateReq.VoucherID;
            spinPrizeExist.SpinID = updateReq.SpinID;
            spinPrizeExist.Probability = updateReq.Probability;
            await _dbContext.SaveChangesAsync();
            return spinPrizeExist;
        }
    }
}
