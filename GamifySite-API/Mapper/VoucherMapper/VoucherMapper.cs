using GamifySite_API.DTO.VoucherDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.VoucherMapper
{
    public static class VoucherMapper
    {

        public static VoucherDto ToVoucherDTO(this Voucher voucherModel)
        {
            return new VoucherDto
            {
                VoucherID = voucherModel.VoucherID,
                DateCreated = voucherModel.DateCreated,
                DateModified = voucherModel.DateModified,
                Ratings = voucherModel.Ratings,
                Special1 = voucherModel.Special1,
                Special2 = voucherModel.Special2,
                Special3 = voucherModel.Special3,
                Stock = voucherModel.Stock,
                Visible = voucherModel.Visible,
                VoucherAmount = voucherModel.VoucherAmount,
                VoucherExpiry = voucherModel.VoucherExpiry,
                VoucherLocation = voucherModel.VoucherLocation,
                VoucherName = voucherModel.VoucherName,
                VoucherStatus = voucherModel.VoucherStatus,
                VoucherType = voucherModel.VoucherType,
                VendorID = voucherModel.VendorID,
            };
        }

        public static Voucher ToVoucherFromCreateDto(this CreateVoucherRequestDTO requestDTO)
        {
            return new Voucher
            {
                VoucherName = requestDTO.VoucherName,
                VoucherStatus = requestDTO.VoucherStatus,
                VoucherType = requestDTO.VoucherType,
                VendorID = requestDTO.VendorID,
                VoucherAmount = requestDTO.VoucherAmount,
                VoucherExpiry = requestDTO.VoucherExpiry,
                VoucherLocation = requestDTO.VoucherLocation,
                Visible= requestDTO.Visible,
                Stock = requestDTO.Stock,
                Ratings = null,

                // Fixed on new creation
                DateCreated = DateTime.UtcNow,
                DateModified = DateTime.UtcNow,
                Special1 = false,
                Special2 = false,
                Special3 = false,
            };

        }

    }
}
