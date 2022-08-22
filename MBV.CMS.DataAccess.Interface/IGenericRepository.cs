namespace MBV.CMS.DataAccess.Interface
{
    public interface IGenericRepository<T> where T : class
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

}
