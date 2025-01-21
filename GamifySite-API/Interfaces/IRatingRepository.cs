using GamifySite_API.DTO.RatingDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IRatingRepository
    {

        Task<List<Rating>> GetAllAsync();
        Task<Rating?> GetByIDAsync(Guid id);
        Task<Rating> CreateAsync(Rating ratingModel);

        Task<Rating?> UpdateAsync(Guid id, UpdateRatingRequestDTO ratingModel);
        Task<Rating?> DeleteAsync(Guid id);
    }
}
