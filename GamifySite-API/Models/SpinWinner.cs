namespace GamifySite_API.Models
{
    public class SpinWinner
    {
        public Guid SpinWinnerID { get; set; }
        public Guid SpinPrizeID { get; set; }
        public Guid WinnerID { get; set; }
        public DateTime DateWon { get; set; }

        public SpinPrize SpinPrize { get; set; }
        public User Winner { get; set; }

    }
}
