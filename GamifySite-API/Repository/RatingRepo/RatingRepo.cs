using GamifySite_API.DBContext;
using GamifySite_API.DTO.RatingDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.RatingRepo
{
    public class RatingRepo : IRatingRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public RatingRepo(ApplicationDBContext dbContext) 
        { 
            _dbContext = dbContext;
        }

        public async Task<Rating> CreateAsync(Rating ratingModel)
        {
            await _dbContext.Rating.AddAsync(ratingModel);
            await _dbContext.SaveChangesAsync();
            return ratingModel;
        }

        public async Task<Rating?> DeleteAsync(Guid id)
        {
            var ratingDelete = await _dbContext.Rating.FirstOrDefaultAsync(x => x.RatingID == id);
            if (ratingDelete == null)
            {
                return null;
            }
            _dbContext.Rating.Remove(ratingDelete);
            await _dbContext.SaveChangesAsync();
            return ratingDelete;
        }

        public async Task<List<Rating>> GetAllAsync()
        {
            return await _dbContext.Rating.ToListAsync();
        }

        public async Task<Rating?> GetByIDAsync(Guid id)
        {

            var rating = await _dbContext.Rating.FirstOrDefaultAsync(r => r.RatingID == id);
            if (rating == null)
            {
                return null;
            }

            return rating;

        }

        public async Task<Rating?> UpdateAsync(Guid id, UpdateRatingRequestDTO ratingModel)
        {
            var ratingUpdate = await _dbContext.Rating.FirstOrDefaultAsync(x => x.RatingID == id);
            if (ratingUpdate == null)
            {
                return null;
            }

            ratingUpdate.RatingValue = ratingModel.RatingValue;
            ratingUpdate.Comment = ratingModel.Comment;
            await _dbContext.SaveChangesAsync();
            return ratingUpdate;
        }
    }
}
