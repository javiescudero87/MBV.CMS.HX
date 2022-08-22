using Microsoft.Extensions.Logging;
using System.Net;

namespace MBV.CMS.Lainco.Exceptions
{
    public sealed class BusinessException : Exception
    {
        public EventId EventId { get; }
        public List<Error> Errors { get; }
        public HttpStatusCode HttpStatusCode { get; set; }

        public BusinessException(List<Error> errors)
        {
            Errors = errors;
        }

        public BusinessException(Error error)
        {
            Errors = new List<Error> { error };
        }
    }
}
