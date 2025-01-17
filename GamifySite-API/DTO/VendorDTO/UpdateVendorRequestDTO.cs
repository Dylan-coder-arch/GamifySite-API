using System.ComponentModel.DataAnnotations;
using GamifySite_API.Models;

namespace GamifySite_API.DTO.VendorDTO
{
    public class UpdateVendorRequestDTO
    {
        [Required]
        [MaxLength(500, ErrorMessage = "Vendor name too long (cannot exceed 500 characters)")]
        public string VendorName { get; set; } = string.Empty;
        [Required]
        public Guid VendorCategoryID { get; set; }
        [Required]
        public Guid ContactID { get; set; }
        [Required]
        public Guid AddressID { get; set; } 
        public string VendorStatus { get; set; } = string.Empty;


    }
}
