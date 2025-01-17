using GamifySite_API.Models;

namespace GamifySite_API.DTO.VendorDTO
{
    public class VendorDTO
    {

        public Guid VendorID { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public Guid VendorCategoryID { get; set; } 
        public Guid ContactID { get; set; } 
        public Guid AddressID { get; set; }
        public string VendorStatus { get; set; } = string.Empty;

        public ICollection<Voucher>? Vouchers { get; set; }

    }
}
