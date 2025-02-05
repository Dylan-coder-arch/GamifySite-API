using GamifySite_API.DTO.VendorCategory;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.VendorCategoryMapper
{
    public static class VendorCatMapper
    {

        public static VendorCategoryDto ToVendorCategoryDTO(this VendorCategory vendCat)
        {
            return new VendorCategoryDto
            {
                Category = vendCat.Category,
                VendorCategoryID = vendCat.VendorCategoryID,
            };
        }

        public static VendorCategory ToVendorCategoryFromCreate(this CreateVendorCategoryDto createReq)
        {
            return new VendorCategory
            {
                Category = createReq.Category,
                VendorCategoryID = Guid.NewGuid(),
            };
        }

    }
}
