using MBV.CMS.HX.DataAccess.Interface;
using NHibernate;
using NHibernate.Exceptions;

namespace MBV.CMS.HX.DataAccess.NHibernate
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>, IGenericRepository where TEntity : class
    {

        private readonly ISession _session;
        private ITransaction? _transaction;

        public GenericRepository(ISession session)
        {
            _session = session;
        }


        public void BeginTransaction()
        {
            if (_session.GetCurrentTransaction() == null || !_session.GetCurrentTransaction().IsActive)
                _transaction = _session.BeginTransaction();
        }

        public async Task CommitAsync()
        {
            if (_transaction == null || !_transaction.IsActive || _transaction.WasCommitted)
                return;
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            if (_transaction == null || !_transaction.IsActive || _transaction.WasCommitted)
                return;
            try
            {
                await _transaction.RollbackAsync();
            }
            catch (GenericADOException)
            {
                _session.Clear();
                _transaction.Dispose();
                Thread.Sleep(500);
                _session.Reconnect();
                throw;
            }
        }

        public void CloseTransaction()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void Dispose()
        {
        }

        public async Task<TEntity?> FindAsync(long id)
        {
            return await _session.GetAsync<TEntity>(id);
        }


        public async Task<TEntity> SaveAsync(TEntity domainEntity)
        {
            BeginTransaction();
            try
            {
                await _session.SaveOrUpdateAsync(domainEntity);
                await CommitAsync();
                return domainEntity;
            }
            catch (Exception)
            {
                await RollbackAsync();
                throw;
            }
        }
    }
}