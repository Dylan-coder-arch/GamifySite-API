using GamifySite_API.Models;
using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.DBContext
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }

        // Vendors 
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<VendorAddress> VendorAddresses { get; set; }
        public DbSet<VendorCategory> VendorCategories { get; set; }

        // Vouchers 
        public DbSet<Voucher> Vouchers { get; set; }
        public DbSet<VoucherDetail> VouchersDetail { get; set; }

        // Tags for vouchers
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagDef> TagsDef { get; set; }

        // Rating
        public DbSet<Rating> Rating { get; set; }

        // Spins
        public DbSet<Spin> Spinners { get; set; }
        public DbSet<SpinPrize> SpinnersPrize { get; set; }
        public DbSet<SpinWinner> SpinWinner { get; set; }

        // Payment
        public DbSet<Payment> Payments { get; set; }

        // 



    }
}
