namespace MBV.CMS.HX.DataAccess.Interface
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<T?> FindAsync(long id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="TEntity"></param>
        /// <returns></returns>
        public Task<T> SaveAsync(T TEntity);

    }

    /// <summary>
    /// Interface to support non-typed entities adding to a repository
    /// </summary>
    public interface IGenericRepository : IDisposable
    {
        void BeginTransaction();
        Task CommitAsync();
        Task RollbackAsync();
        void CloseTransaction();

    }

}
