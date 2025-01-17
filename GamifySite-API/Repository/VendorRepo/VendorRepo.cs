using GamifySite_API.DBContext;
using GamifySite_API.DTO.UserDTO;
using GamifySite_API.DTO.VendorDTO;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.VendorRepo
{
    public class VendorRepo : IVendorRepository
    {

        private readonly ApplicationDBContext _dbContext;
        public VendorRepo(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Vendor> CreateAsync(Vendor vendorModel)
        {
            await _dbContext.Vendors.AddAsync(vendorModel);
            await _dbContext.SaveChangesAsync();
            return vendorModel;
        }

        public async Task<Vendor?> DeleteAsync(Guid id)
        {
            var vendorModel = await _dbContext.Vendors.FirstOrDefaultAsync(x => x.VendorID == id);
            if (vendorModel == null)
            {
                return null;
            }

            _dbContext.Vendors.Remove(vendorModel);
            await _dbContext.SaveChangesAsync();
            return vendorModel;

        }

        public async Task<bool> Exists(Guid id)
        {
            var vendorModel = await _dbContext.Vendors.FirstOrDefaultAsync(x => x.VendorID == id);
            return vendorModel != null;
        }

        public async Task<List<Vendor>> GetAllAsync()
        {
            return await _dbContext.Vendors.ToListAsync();
        }

        public async Task<Vendor?> GetByIDAsync(Guid id)
        {
            return await _dbContext.Vendors.FirstOrDefaultAsync(x => x.VendorID == id);
        }

        public async Task<Vendor?> UpdateAsync(Guid id, UpdateVendorRequestDTO updateReq)
        {
            var vendorModel = await _dbContext.Vendors.FirstOrDefaultAsync(x => x.VendorID == id);
            if (vendorModel == null)
            {
                return null;
            }

            vendorModel.VendorName = updateReq.VendorName;
            vendorModel.AddressID = updateReq.AddressID;
            vendorModel.VendorCategoryID = updateReq.VendorCategoryID;
            vendorModel.ContactID = updateReq.ContactID;
            vendorModel.VendorStatus = updateReq.VendorStatus;
            await _dbContext.SaveChangesAsync();
            return vendorModel;
        }
    }
}
