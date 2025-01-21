using GamifySite_API.DTO.RatingDTO;
using GamifySite_API.Models;

namespace GamifySite_API.DTO.UserDTO
{
    public class UserDTO
    {
        public Guid UserID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Role { get; set; } = "user";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<RatingDto>? Ratings { get; set; }


    }
}
