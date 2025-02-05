using GamifySite_API.DBContext;
using GamifySite_API.Interfaces;
using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.Repository.VendorAddrRepo
{
    public class VendorAddressRepo : IVendorAddressRepository
    {
        private readonly ApplicationDBContext _context;
        public VendorAddressRepo(ApplicationDBContext context) 
        { 
            _context = context;
        
        }

        public async Task<VendorAddress> CreateAsync(VendorAddress value)
        {
            await _context.VendorAddresses.AddAsync(value);
            await _context.SaveChangesAsync();
            return value;
        }

        public async Task<VendorAddress?> DeleteAsync(Guid id)
        {
            var vendAddrDel = await _context.VendorAddresses.FirstOrDefaultAsync(va => va.VendorAddressID == id);
            if (vendAddrDel == null)
            {
                return null;
            }
            _context.VendorAddresses.Remove(vendAddrDel);
            await _context.SaveChangesAsync();
            return vendAddrDel;
        }

        public async Task<List<VendorAddress>> GetAllAsync()
        {
            return await _context.VendorAddresses.ToListAsync();
        }

        public async Task<VendorAddress?> GetByIDAsync(Guid id)
        {
            var vendAddr = await _context.VendorAddresses.FirstOrDefaultAsync(va => va.VendorAddressID == id);
            if (vendAddr == null)
            {
                return null;
            }
            return vendAddr;
        }

        public async Task<VendorAddress?> UpdateAsync(Guid id, VendorAddress value)
        {
            var vendAddrUpdate = await _context.VendorAddresses.FirstOrDefaultAsync(va =>va.VendorAddressID == id);
            if (vendAddrUpdate == null)
            {
                return null;
            }
            vendAddrUpdate.State = value.State;
            vendAddrUpdate.StreetAddress = value.StreetAddress;
            vendAddrUpdate.City = value.City;
            vendAddrUpdate.Country = value.Country;
            vendAddrUpdate.PostalCode = value.PostalCode;
            await _context.SaveChangesAsync();
            return vendAddrUpdate;
        }
    }
}
