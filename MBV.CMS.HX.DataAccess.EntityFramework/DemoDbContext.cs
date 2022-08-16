using Microsoft.EntityFrameworkCore;

namespace MBV.CMS.HX.DataAccess.EntityFramework
{
    public class DemoDbContext : DbContext
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options)
        {
        }

        public DbSet<Domain.MBCar> Demos { get; set; }
    }
}
