using GamifySite_API.DTO.RatingDTO;

namespace GamifySite_API.Models
{
    public class Voucher
    {

        public Guid VoucherID { get; set; }
        public string VoucherName { get; set; } = string.Empty;
        public string VoucherType { get; set; } = string.Empty;
        public Guid VendorID { get; set; }
        public decimal VoucherAmount { get; set; }
        public DateTime VoucherExpiry { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public DateTime DateModified { get; set; } = DateTime.UtcNow;
        public string VoucherStatus { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string VoucherLocation { get; set; } = string.Empty;
        public bool Visible { get; set; }
        public bool Special1 { get; set; }
        public bool Special2 { get; set; }
        public bool Special3 { get; set; }

        public Vendor Vendor { get; set; }
        public ICollection<Rating> Ratings { get; set; } = new List<Rating>();
        public ICollection<Tag> Tags { get; set; } = new List<Tag>();
        // public ICollection<RafflePrize> RafflePrizes { get; set; }

    }
}
