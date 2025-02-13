using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.SpinWinnerRepo
{
    public class SpinWinnerRepo : ISpinWinnerRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public SpinWinnerRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SpinWinner> CreateAsync(SpinWinner spinWinner)
        {
            await _dbContext.SpinWinner.AddAsync(spinWinner);
            await _dbContext.SaveChangesAsync();
            return spinWinner;
        }

        public async Task<List<SpinWinner>> GetAllAsync()
        {
            return await _dbContext.SpinWinner.ToListAsync();
        }

        public async Task<SpinWinner?> GetByIDAsync(Guid id)
        {
            var spinWin = await _dbContext.SpinWinner.FirstOrDefaultAsync(sw => sw.SpinWinnerID == id);
            if (spinWin == null)
            {
                return null;
            }
            return spinWin;
        }
    }
}
