namespace GamifySite_API.DTO.VoucherDTO
{
    public class CreateVoucherRequestDTO
    {

        public string VoucherName { get; set; } = string.Empty;
        public string VoucherType { get; set; } = string.Empty;
        public Guid VendorID { get; set; }
        public decimal VoucherAmount { get; set; } // % disc, monetary disc? 
        public DateTime VoucherExpiry { get; set; }
        public string VoucherStatus { get; set; } = string.Empty;
        public int Stock { get; set; }
        public string VoucherLocation { get; set; } = string.Empty;
        public bool Visible { get; set; } // some vouchers are for spins only, visible means on the store or not (on spin)

    }
}
