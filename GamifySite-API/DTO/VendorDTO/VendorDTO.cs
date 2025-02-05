using GamifySite_API.DTO.VoucherDTO;
using GamifySite_API.Models;

namespace GamifySite_API.DTO.VendorDTO
{
    public class VendorDTO
    {

        public Guid VendorID { get; set; }
        public string VendorName { get; set; } = string.Empty;
        public Guid VendorCategoryID { get; set; } 
        public Guid UserID { get; set; } 
        public Guid VendorAddressID { get; set; }
        public string VendorStatus { get; set; } = string.Empty;

        public ICollection<VoucherDto>? Vouchers { get; set; } = new List<VoucherDto>();

    }
}
