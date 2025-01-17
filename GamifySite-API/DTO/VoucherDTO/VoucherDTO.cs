using GamifySite_API.Models;

namespace GamifySite_API.DTO.VoucherDTO
{
    public class VoucherDTO
    {   
        public Guid VoucherID { get; set; }
        public string VoucherName { get; set; } = string.Empty;
        public string VoucherType { get; set; } = string.Empty;
        public Guid VoucherVendor { get; set; }
        public decimal VoucherAmount { get; set; } // % disc, monetary disc? 
        public DateTime VoucherExpiry { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public string VoucherStatus { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string VoucherLocation { get; set; } = string.Empty;
        public bool Visible { get; set; } // some vouchers are for spins only, visible means on the store or not (on spin)
        public bool Special1 { get; set; }
        public bool Special2 { get; set; }
        public bool Special3 { get; set; }

        public ICollection<Rating>? Ratings { get; set; }

    }
}
