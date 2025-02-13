using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.TagRepo
{
    public class TagRepo : ITagRepo
    {
        private readonly ApplicationDBContext _dbContext;
        public TagRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Tag> AddTagAsync(Tag tagItem)
        {
            await _dbContext.Tags.AddAsync(tagItem);
            await _dbContext.SaveChangesAsync();
            return tagItem;
        }

        public async Task<Tag?> DeleteTagAsync(Guid tagID)
        {
            var tagExists = await _dbContext.Tags.FirstOrDefaultAsync(x => x.TagID == tagID);
            if (tagExists == null)
            {
                return null;
            }
            _dbContext.Tags.Remove(tagExists);
            await _dbContext.SaveChangesAsync();
            return tagExists;
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            return await _dbContext.Tags.ToListAsync();
        }

        public async Task<Tag?> GetByIdAsync(Guid tagID)
        {
            var tagExist = await _dbContext.Tags.FirstOrDefaultAsync(x => x.TagID == tagID);
            if (tagExist == null)
            {
                return null;
            }
            return tagExist;
        }

        public Task<Tag?> TagAlreadyAddedAsync(Guid voucherID, Guid tagDefID)
        {
            throw new NotImplementedException();
        }

        public async Task<Tag?> UpdateTagAsync(Guid tagID, Tag tagUpdate)
        {
            var tagExist = await _dbContext.Tags.FirstOrDefaultAsync(x => x.TagID == tagID);
            if (tagExist == null)
            {
                return null;
            }
            tagExist.TagDefID = tagUpdate.TagDefID;
            await _dbContext.SaveChangesAsync();
            return tagExist;
        }
    }
}
