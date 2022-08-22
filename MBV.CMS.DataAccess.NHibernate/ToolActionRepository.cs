using MBV.CMS.HX.DataAccess.Interface;
using NHibernate;

namespace MBV.CMS.HX.DataAccess.NHibernate
{
    public class ToolActionRepository : GenericRepository<Domain.ToolAction>, IToolActionRepository
    {
        public ToolActionRepository(ISession session) : base (session)
        {

        }
    }
}
