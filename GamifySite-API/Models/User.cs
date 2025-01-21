using GamifySite_API.DTO.RatingDTO;

namespace GamifySite_API.Models
{
    public class User
    {

        public Guid UserID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public List<Rating> Ratings { get; set; } = new List<Rating>();
        // public ICollection<Participant> Participants { get; set; }


    }
}
