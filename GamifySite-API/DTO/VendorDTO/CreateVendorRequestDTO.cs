﻿using GamifySite_API.Models;

namespace GamifySite_API.DTO.VendorDTO
{
    public class CreateVendorRequestDTO
    {
        
        public string VendorName { get; set; } = string.Empty;
        public Guid VendorCategoryID { get; set; } 
        public Guid UserID { get; set; } 
        public Guid VendorAddressID { get; set; }


    }
}
