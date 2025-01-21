using GamifySite_API.DTO.VoucherDTO;

namespace GamifySite_API.Models
{
    public class Vendor
    {
        public Guid VendorID { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public Guid VendorCategoryID { get; set; } 
        public Guid UserID { get; set; }
        public Guid VendorAddressID { get; set; }
        public string VendorStatus { get; set; } = string.Empty;

        public User User { get; set; }
        public VendorAddress Address { get; set; }
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();


    }
}
