using GamifySite_API.DTO.UserDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface IUserRepository
    {

        Task<List<User>> GetAllAsync();
        Task<User?> GetByIDAsync(Guid id);
        Task<User?> GetByEmailAsync(string email);
        
        Task<User> CreateAsync(User userModel);
        Task<User?> UpdateAsync(Guid id, UpdateUserRequestDTO updateReq);
        Task<User?> DeleteAsync(Guid id);

        Task<bool> Exists(Guid id);
    }
}
