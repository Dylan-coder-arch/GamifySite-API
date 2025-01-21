namespace GamifySite_API.DTO.RatingDTO
{
    public class CreateRatingRequestDTO
    {

        public decimal RatingValue { get; set; }
        public string Comment { get; set; } = string.Empty;

        public Guid UserID { get; set; }
    }
}
