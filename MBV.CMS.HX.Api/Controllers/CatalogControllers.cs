using MBV.CMS.HX.Api.Models;
using MBV.CMS.HX.Domain.Catalog;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace MBV.CMS.HX.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(RouteRoot)]
    public class CatalogControllers : Controller
    {
        private const string RouteRoot = "api/v{version:apiVersion}/catalog";

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("actions")]
        [SwaggerOperation(Summary = "Gets a Catalog for all existing actions.", Tags = new[] { "Catalog" })]
        [ProducesResponseType(typeof(ActionCatalogEntry), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        
        public async Task<IActionResult> Actions()
        {
            var instance = Catalog.Instance;
            var result = instance.RegisteredActions;
            return Ok(result);
        }
    }
}
