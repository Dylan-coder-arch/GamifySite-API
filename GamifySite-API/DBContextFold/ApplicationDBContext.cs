using Microsoft.EntityFrameworkCore;

namespace GamifySite_API.DBContext
{
    public class ApplicationDBContext : DbContext
    {

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) 
        { 
        
        }

    }
}
