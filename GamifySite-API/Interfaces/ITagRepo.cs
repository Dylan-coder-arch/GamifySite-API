using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface ITagRepo
    {
        // need to edit this and think about it
        // making the api for a blended table is a little tricky 
        Task<List<Tag>> GetAllAsync();
        Task<Tag?> GetByIdAsync(Guid tagID);
        //Task<Tag?> GetByVoucherID(Guid vouchID);
        //Task<List<Voucher>> GetAllByTagDef(Guid tagDefID);
        Task<Tag> AddTagAsync(Tag tagItem);
        Task<Tag?> UpdateTagAsync(Guid tagID, Tag tagUpdate);
        Task<Tag?> DeleteTagAsync(Guid tagID);
        Task<Tag?> TagAlreadyAddedAsync(Guid voucherID, Guid tagDefID);
    }
}
