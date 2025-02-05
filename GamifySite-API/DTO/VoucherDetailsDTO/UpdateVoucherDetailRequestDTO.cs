namespace GamifySite_API.DTO.VoucherDetailsDTO
{
    public class UpdateVoucherDetailRequestDTO
    {

        
        public string VoucherCode { get; set; } = string.Empty;
        public string VoucherCodeStatus { get; set; } = string.Empty;
        public Guid VoucherID { get; set; }
        public Guid? UserID { get; set; }
        public DateTime? ClaimedTime { get; set; }

    }
}
