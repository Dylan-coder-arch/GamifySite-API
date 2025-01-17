using GamifySite_API.Models;

namespace GamifySite_API.DTO.UserDTO
{
    public class UpdateUserRequestDTO
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;


    }
}
