using GamifySite_API.Models;

namespace GamifySite_API.DTO.RatingDTO
{
    public class RatingDto
    {

        public Guid RatingID { get; set; }
        public Guid VoucherID { get; set; }
        public Guid UserID { get; set; }
        public decimal RatingValue { get; set; }
        public string Comment { get; set; } = string.Empty;

    }
}
