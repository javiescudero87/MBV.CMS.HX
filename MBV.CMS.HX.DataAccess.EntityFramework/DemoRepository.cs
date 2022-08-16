using MBV.CMS.HX.DataAccess.Interface;

namespace MBV.CMS.HX.DataAccess.EntityFramework
{
    public class DemoRepository : GenericRepository<Domain.MBCar>, IMBCarRepository
    {
        public DemoRepository(DemoDbContext dbContext) : base(dbContext)
        {
        }

    }
}
