using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.VendorCategoryRepo
{
    public class VendorCategoryRepo : IVendorCategoryRepository
    {
        private readonly ApplicationDBContext _context;
        public VendorCategoryRepo(ApplicationDBContext context)         
        { 
            _context = context;
        
        }
        public async Task<VendorCategory> CreateAsync(VendorCategory v)
        {
            await _context.VendorCategories.AddAsync(v);
            await _context.SaveChangesAsync();
            return v;
        }

        public async Task<VendorCategory?> DeleteAsync(Guid id)
        {
            var vendCatExist = await _context.VendorCategories.FirstOrDefaultAsync(vc => vc.VendorCategoryID == id);
            if (vendCatExist == null)
            {
                return null;
            }
            _context.VendorCategories.Remove(vendCatExist);
            await _context.SaveChangesAsync();
            return vendCatExist;
        }

        public async Task<List<VendorCategory>> GetAllAsync()
        {
            return await _context.VendorCategories.ToListAsync();
        }

        public async Task<VendorCategory?> GetByID(Guid id)
        {
            var vendCatExist = await _context.VendorCategories.FirstOrDefaultAsync(vc => vc.VendorCategoryID == id);
            if (vendCatExist == null)
            {
                return null;
            }
            return vendCatExist;
        }

        public async Task<VendorCategory?> UpdateAsync(Guid id, VendorCategory v)
        {
            var upExist = await _context.VendorCategories.FirstOrDefaultAsync(_ => _.VendorCategoryID == id);
            if (upExist == null)
            {
                return null;
            }
            upExist.Category = v.Category;
            await _context.SaveChangesAsync();
            return upExist;
        }
    }
}
