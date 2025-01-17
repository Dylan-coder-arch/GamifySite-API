using System.ComponentModel.DataAnnotations;
using GamifySite_API.Models;

namespace GamifySite_API.DTO.UserDTO
{
    public class CreateUserRequestDTO
    {
        [Required]
        
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required] public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(10, ErrorMessage = "Phone number cannot be longer than 10 characters")]
        public string PhoneNo { get; set; } = string.Empty;


    }
}
