using GamifySite_API.Models;
using GamifySite_API.DTO.SpinPrizeDTO;

namespace GamifySite_API.DTO.SpinDTO
{
    public class SpinDTO
    {

        public Guid SpinID { get; set; }
        public string SpinName { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public ICollection<SpinPrizeDto>? SpinPrizes { get; set; }

    }
}
