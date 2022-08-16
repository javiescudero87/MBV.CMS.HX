using MBV.CMS.HX.DataAccess.Interface;
using NHibernate;

namespace MBV.CMS.HX.DataAccess.NHibernate
{
    public class MBCarRepository : GenericRepository<Domain.MBCar>, IMBCarRepository
    {
        public MBCarRepository(ISession session) : base(session)
        {
        }

    }
}
