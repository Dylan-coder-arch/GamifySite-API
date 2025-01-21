using GamifySite_API.DTO.RatingDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.RatingMapper
{
    public static class RatingMapper
    {

        public static RatingDto ToRatingDto(this Rating rating)
        {
            return new RatingDto
            {
                RatingID = rating.RatingID,
                Comment = rating.Comment,
                RatingValue = rating.RatingValue,
                UserID = rating.UserID,
                VoucherID = rating.VoucherID
            };
        }
        
        public static Rating ToRatingFromCreateDto(this CreateRatingRequestDTO ratingReq, Guid voucherID)
        {
            return new Rating
            {
                Comment = ratingReq.Comment,
                RatingValue = ratingReq.RatingValue,
                VoucherID = voucherID,
                UserID = ratingReq.UserID
            };
        }

    }
}
