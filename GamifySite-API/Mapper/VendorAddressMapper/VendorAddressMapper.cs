using GamifySite_API.DTO.VendorAddressDTO;
using GamifySite_API.Models;


namespace GamifySite_API.Mapper.VendorAddressMapper
{
    public static class VendorAddressMapper
    {

        public static VendorAddressDTO ToVendorAddressDTO(this VendorAddress vendAddressModel)
        {
            return new VendorAddressDTO
            {
                City = vendAddressModel.City,
                Country = vendAddressModel.Country,
                PostalCode = vendAddressModel.PostalCode,
                State = vendAddressModel.State,
                StreetAddress = vendAddressModel.StreetAddress,
                VendorAddressID = vendAddressModel.VendorAddressID,
                
            };
        }

        public static VendorAddress ToVendorFromCreateDTO(this CreateVendorAddressDTO vendorAddressCreateModel)
        {
            return new VendorAddress
            {
                City = vendorAddressCreateModel.City,
                Country = vendorAddressCreateModel.Country,
                PostalCode= vendorAddressCreateModel.PostalCode,
                State = vendorAddressCreateModel.State,
                StreetAddress= vendorAddressCreateModel.StreetAddress,

            };
        }

    }
}
