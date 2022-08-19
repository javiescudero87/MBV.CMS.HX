using Microsoft.AspNetCore.Mvc.Filters;
using NHibernate;
using ISession = NHibernate.ISession;

namespace MBV.CMS.HX.Api.Filters
{
    /// <summary>
    /// TransactionAttribute
    /// </summary>
    public class TransactionAttribute: ActionFilterAttribute
    {
        readonly ISession _session;
        ITransaction _transaction;

        /// <summary>
        /// TransactionAttribute
        /// </summary>
        /// <param name="session"></param>
        public TransactionAttribute(ISession session)
        {
            _session = session;
            _transaction = _session.GetCurrentTransaction();
        }


        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _transaction = _session.BeginTransaction();
        }

        /// <summary>
        /// OnActionExecuted
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            if (_transaction.IsActive)
            {
                if (context.Exception is null)
                    _transaction.Commit();
                else
                    _transaction.Rollback();
            }

            DisposeTransaction();
            CloseSession();
        }

        private void DisposeTransaction()
        {
            _transaction.Dispose();
            _transaction = null;
        }

        private void CloseSession()
        {
            _session.Flush();
            _session.Close();
            _session.Dispose();
        }
    }
}
