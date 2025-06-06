﻿namespace GamifySite_API.DTO.VendorAddressDTO
{
    public class VendorAddressDTO
    {

        public Guid VendorAddressID { get; set; }
        public string StreetAddress { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;

    }
}
