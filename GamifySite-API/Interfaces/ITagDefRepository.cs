using GamifySite_API.Models;

namespace GamifySite_API.Interfaces
{
    public interface ITagDefRepository
    {

        Task<List<TagDef>> GetAllAsync();
        Task<TagDef?> GetByIdAsync(Guid id);
        // Task<TagDef?> GetByName(string name);
        Task<TagDef?> DeleteAsync(Guid id);
        Task<TagDef?> UpdateTagAsync(Guid id, TagDef tagDef);
        Task<TagDef> CreateTagAsync(TagDef tagDef);


    }
}
