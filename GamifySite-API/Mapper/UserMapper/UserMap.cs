using GamifySite_API.DTO.UserDTO;
using GamifySite_API.Mapper.RatingMapper;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.UserMapper
{
    public static class UserMap
    {

        public static UserDTO ToUserDto(this User userModel)
        {
            return new UserDTO
            {
                UserID = userModel.UserID,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                Password = userModel.Password,
                PhoneNo = userModel.PhoneNo,
                CreatedAt = userModel.CreatedAt,
                Ratings = userModel.Ratings.Select(r => r.ToRatingDto()).ToList(),
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDTO createUserRequestDTO)
        {
            return new User
            {
                FirstName = createUserRequestDTO.FirstName,
                LastName = createUserRequestDTO.LastName,
                Email = createUserRequestDTO.Email,
                Password = createUserRequestDTO.Password,
                PhoneNo = createUserRequestDTO.PhoneNo,
                Role = "user",
                CreatedAt = DateTime.UtcNow,
            };
        }

        

    }
}
