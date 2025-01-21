namespace GamifySite_API.DTO.RatingDTO
{
    public class UpdateRatingRequestDTO
    {

        public decimal RatingValue { get; set; }
        public string Comment { get; set; } = string.Empty;

    }
}
