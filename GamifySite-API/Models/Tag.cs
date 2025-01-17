namespace GamifySite_API.Models
{
    public class Tag
    {
        public Guid TagID { get; set; }
        public Guid VoucherID { get; set; }
        public Guid TagDefID { get; set; }

        public Voucher Voucher { get; set; }
        public TagDef TagDefinition { get; set; }

    }
}
