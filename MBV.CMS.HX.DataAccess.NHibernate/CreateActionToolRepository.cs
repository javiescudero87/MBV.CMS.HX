using MBV.CMS.HX.DataAccess.Interface;
using NHibernate;

namespace MBV.CMS.HX.DataAccess.NHibernate
{
    public class CreateActionToolRepository : GenericRepository<Domain.CreateToolAction>, ICreateActionToolRepository
    {
        public CreateActionToolRepository(ISession session) : base (session)
        {

        }
    }
}
