using GamifySite_API.DTO.VoucherDetailsDTO;
using GamifySite_API.Models;

namespace GamifySite_API.Mapper.VoucherDetailMapper
{
    public static class VoucherDetailMapper
    {

        public static VoucherDetailsDto ToVoucherDetailDTO(this VoucherDetail vouchDetailModel)
        {
            return new VoucherDetailsDto
            {
                VoucherDetailID = vouchDetailModel.VoucherDetailID,
                UserID = vouchDetailModel.UserID,
                ClaimedTime = vouchDetailModel.ClaimedTime,
                VoucherCode = vouchDetailModel.VoucherCode,
                VoucherCodeStatus = vouchDetailModel.VoucherCodeStatus,
                VoucherID = vouchDetailModel.VoucherID,
            };
        }

        public static VoucherDetail ToVoucherDetailFromCreate(this CreateVoucherDetailsRequestDTO createVouchDetail)
        {
            return new VoucherDetail
            {
                VoucherDetailID = Guid.NewGuid(),
                VoucherID = createVouchDetail.VoucherID,
                VoucherCode = createVouchDetail.VoucherCode,
                VoucherCodeStatus = createVouchDetail.VoucherCodeStatus,
                UserID = createVouchDetail.UserID,
                ClaimedTime = createVouchDetail.ClaimedTime,
            };
        }

    }
}
