using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface ITagRepo
    {
        // need to edit this and think about it
        // making the api for a blended table is a little tricky 
        Task<List<Tag>> GetAll();
        Task<Tag?> GetByVoucherID(Guid vouchID);
        Task<List<Voucher>> GetAllByTagDef(Guid tagDefID);
        Task<Tag> CreateTag(Guid voucherID, Guid tagDefID);
        Task<Tag?> UpdateTag(Guid tagID);
        Task<Tag?> DeleteTag(Guid tagID);
        Task<Tag?> TagAlreadyAdded(Guid voucherID, Guid tagDefID);
    }
}
