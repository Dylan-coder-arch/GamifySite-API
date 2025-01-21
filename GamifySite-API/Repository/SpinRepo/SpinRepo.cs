using GamifySite_API.DBContext;
using GamifySite_API.DTO.SpinDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.SpinRepo
{
    public class SpinRepo : ISpinRepositry
    {

        private readonly ApplicationDBContext _dbContext;
        public SpinRepo(ApplicationDBContext dbContext) 
        {
            _dbContext = dbContext; 
        }

        public async Task<Spin> CreateAsync(Spin spinModel)
        {
            await _dbContext.Spinners.AddAsync(spinModel);
            await _dbContext.SaveChangesAsync();
            return spinModel;
        }

        public async Task<Spin?> DeleteAsync(Guid id)
        {
            var spinExist = await _dbContext.Spinners.FirstOrDefaultAsync(s => s.SpinID == id);
            if (spinExist == null)
            {
                return null;
            }
            _dbContext.Spinners.Remove(spinExist);
            await _dbContext.SaveChangesAsync();
            return spinExist;
        }

        public async Task<List<Spin>> GetAllAsync()
        {
            return await _dbContext.Spinners.ToListAsync();
        }

        public async Task<Spin?> GetByIDAsync(Guid id)
        {
            var spinExist = await _dbContext.Spinners.Include(sp => sp.SpinPrizes).FirstOrDefaultAsync(s => s.SpinID == id);
            if (spinExist == null)
            {
                return null;
            }
            return spinExist;
        }

        public async Task<Spin?> UpdateAsync(Guid id, UpdateSpinRequestDTO updateReq)
        {
            var spinExist = await _dbContext.Spinners.FirstOrDefaultAsync(s => s.SpinID ==id);
            if (spinExist == null)
            {
                return null;
            }

            spinExist.SpinName = updateReq.SpinName;
            await _dbContext.SaveChangesAsync();
            return spinExist;
        }
    }
}
