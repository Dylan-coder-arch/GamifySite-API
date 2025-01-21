namespace GamifySite_API.Models
{
    public class SpinWinner
    {
        public Guid SpinWinnerID { get; set; }
        public Guid SpinPrizeID { get; set; }
        public Guid UserID { get; set; }
        public DateTime DateWon { get; set; } = DateTime.UtcNow;

        public SpinPrize SpinPrize { get; set; }
        public User Winner { get; set; }

    }
}
