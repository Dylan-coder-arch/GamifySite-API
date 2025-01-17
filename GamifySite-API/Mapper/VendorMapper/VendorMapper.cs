using GamifySite_API.DTO.VendorDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.VendorMapper
{
    public static class VendorMapper
    {

        public static VendorDTO ToVendorDto(this Vendor vendorModel)
        {
            return new VendorDTO
            {
                VendorID = vendorModel.VendorID,
                VendorName = vendorModel.VendorName,
                VendorCategoryID = vendorModel.VendorCategoryID,
                VendorStatus = vendorModel.VendorStatus,
                AddressID = vendorModel.AddressID,
                ContactID = vendorModel.ContactID,
                Vouchers = vendorModel.Vouchers,
            };
        }

        public static Vendor ToVendorFromCreate(this CreateVendorRequestDTO vendorModel)
        {
            return new Vendor
            {
                VendorName = vendorModel.VendorName,
                VendorStatus = "active",
                VendorCategoryID = vendorModel.VendorCategoryID,
                AddressID = vendorModel.AddressID,
                ContactID = vendorModel.ContactID,
                Vouchers = null
            };

        }

    }
}
