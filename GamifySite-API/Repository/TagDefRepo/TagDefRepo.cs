using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.TagDefRepo
{
    public class TagDefRepo : ITagDefRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public TagDefRepo(ApplicationDBContext db_context) 
        { 
            _dbContext = db_context;
        }

        public async Task<TagDef> CreateTagAsync(TagDef tagDef)
        {
            await _dbContext.TagsDef.AddAsync(tagDef);
            await _dbContext.SaveChangesAsync();
            return tagDef;
        }

        public async Task<TagDef?> DeleteAsync(Guid id)
        {
            var searchTag = await _dbContext.TagsDef.FindAsync(id);
            if (searchTag == null)
            {
                return null;
            }
            _dbContext.TagsDef.Remove(searchTag);
            await _dbContext.SaveChangesAsync();
            return searchTag;
        }

        public async Task<List<TagDef>> GetAllAsync()
        {
            return await _dbContext.TagsDef.ToListAsync();
        }

        public async Task<TagDef?> GetByIdAsync(Guid id)
        {
            var searchTag = await _dbContext.TagsDef.FindAsync(id);
            if (searchTag == null)
            {
                return null;
            }
            return searchTag;
        }

        
        public async Task<TagDef?> UpdateTagAsync(Guid id, TagDef tagDef)
        {
            var searchTag = await _dbContext.TagsDef.FindAsync(id);
            if (searchTag == null)
            {
                return null;
            }
            searchTag.TagColor = tagDef.TagColor;
            searchTag.TagName = tagDef.TagName;
            await _dbContext.SaveChangesAsync();
            return searchTag;
        }
    }
}
