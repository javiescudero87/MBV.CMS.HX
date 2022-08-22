using MBV.CMS.DataAccess.Interface;
using NHibernate;

namespace MBV.CMS.DataAccess.NHibernate
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {

        private readonly ISession _session;

        public GenericRepository(ISession session)
        {
            _session = session;
        }


        public async Task<TEntity?> FindAsync(long id)
        {
            return await _session.GetAsync<TEntity>(id);
        }


        public async Task<TEntity> SaveAsync(TEntity domainEntity)
        {
                await _session.SaveAsync(domainEntity);
                return domainEntity;
        }
    }
}