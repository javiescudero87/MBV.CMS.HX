using AutoMapper;
using MBV.CMS.HX.Api.Models;
using MBV.CMS.HX.Api.ViewModels;
using MBV.CMS.HX.Domain.Actions;
using MBV.CMS.HX.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Prometheus;
using Swashbuckle.AspNetCore.Annotations;
using System.Dynamic;
using System.Net.Mime;
using System.Reflection;
using YamlDotNet.Core.Tokens;

namespace MBV.CMS.HX.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route(RouteRoot)]
    public class ActionsController : Controller
    {
        private const string RouteRoot = "api/v{version:apiVersion}/actions";

        private readonly ILogger<IAction> _logger;
        private readonly IMapper _mapper;
        private readonly IMBCarService _mBCarService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="mBCarService"></param>
        public ActionsController(ILogger<IAction> logger
            , IMapper mapper
            , IMBCarService mBCarService)
        {
            _logger = logger;
            _mapper = mapper;
            _mBCarService = mBCarService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Creates a new Action", Tags = new[] { "Actions" })]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> CreateMBCarAsync(string type, [FromBody] string body)
        {
            _logger.LogDebug("Entering to Mercedes-Benz cars controller -> CreateMBCarAsync");
            var _type = Type.GetType(type);
            var _arguments = JsonConvert.DeserializeObject(body, _type);

            //Mapper si tengo DTO, sino no hace falta

            //var domainMBCarAdded = await _mBCarService.CreateMBCarAsync(domainMBCar);

            //return Created($"{RouteRoot}/{domainMBCarAdded.Id}", _mapper.Map<MBCarResponse>(domainMBCarAdded));
            return Created("", null);
        }

    }
}
