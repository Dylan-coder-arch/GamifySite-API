namespace GamifySite_API.Models
{
    public class Spin
    {
        public Guid SpinID { get; set; }
        public string SpinName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public ICollection<SpinPrize> SpinPrizes { get; set; } = new List<SpinPrize>();


    }
}
