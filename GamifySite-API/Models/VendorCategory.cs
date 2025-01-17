using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Models
{
    public class VendorCategory
    {
        
        public Guid VendorCategoryID { get; set; }
        public string Category { get; set; } = string.Empty;

    }
}
