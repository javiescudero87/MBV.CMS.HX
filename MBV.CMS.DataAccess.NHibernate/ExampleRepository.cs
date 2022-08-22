using MBV.CMS.DataAccess.Interface;
using NHibernate;

namespace MBV.CMS.DataAccess.NHibernate
{
    public class ExampleRepository : GenericRepository<Domain.ExampleEntity>, IExampleRepository
    {
        public ExampleRepository(ISession session) : base(session)
        {
        }

    }
}
