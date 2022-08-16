using Correlate;
using MBV.CMS.HX.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace MBV.CMS.HX.Api.Filters
{
    /// <summary>
    /// ModelStateValidateAttribute
    /// </summary>
    public class ModelStateValidateAttribute : ActionFilterAttribute
    {
        private readonly ICorrelationContextAccessor _correlation;

        /// <summary>
        /// ModelStateValidateAttribute
        /// </summary>
        public ModelStateValidateAttribute(ICorrelationContextAccessor correlation)
        {
            _correlation = correlation;
        }

        /// <summary>
        /// OnActionExecuting
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = BadRequestResponse(context);
            }
        }

        private IActionResult BadRequestResponse(ActionExecutingContext context)
        {
            var response = new ErrorDetailModel
            {
                EventId = HttpStatusCode.BadRequest.ToString(),
                Detail = "One o more validation error ocurred.",
                CorrelationId = _correlation.CorrelationContext?.CorrelationId
            };
            foreach (var error in context.ModelState.SelectMany(item => item.Value.Errors))
            {
                response.Errors.Add(new Error
                {
                    Code = ((int)HttpStatusCode.BadRequest).ToString(),
                    Detail = error.ErrorMessage,
                });
            }

            return new BadRequestObjectResult(response);
        }
    }
}
