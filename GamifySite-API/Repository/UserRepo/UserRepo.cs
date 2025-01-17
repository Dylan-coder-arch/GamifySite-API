using GamifySite_API.DBContext;
using GamifySite_API.DTO.UserDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.UserRepo
{
    public class UserRepo : IUserRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public UserRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User> CreateAsync(User userModel)
        {
            await _dbContext.Users.AddAsync(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> DeleteAsync(Guid id)
        {
            var userModel = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if (userModel == null)
            {
                return null;
            }
            _dbContext.Users.Remove(userModel);
            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _dbContext.Users.ToListAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.Email.ToUpper() == email.ToUpper());
        }

        public async Task<User?> GetByIDAsync(Guid id)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
        }

        public async Task<User?> UpdateAsync(Guid id, UpdateUserRequestDTO updateReq)
        {
            var userModel = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
            if (userModel == null)
            {
                return null;
            }

            userModel.PhoneNo = updateReq.PhoneNo;
            userModel.Email = updateReq.Email;
            userModel.FirstName = updateReq.FirstName;
            userModel.LastName = updateReq.LastName;


            await _dbContext.SaveChangesAsync();
            return userModel;
        }

        public async Task<bool> Exists(Guid id)
        {
            var model = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserID == id);
            return model != null;
        }
    }
}
