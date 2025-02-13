namespace GamifySite_API.DTO.SpinWinnerDTO
{
    public class SpinWinnerDto
    {
        public Guid SpinWinnerID { get; set; }
        public Guid SpinPrizeID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateWon { get; set; } = DateTime.UtcNow;

    }
}
