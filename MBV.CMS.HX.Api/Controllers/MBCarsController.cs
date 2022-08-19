using AutoMapper;
using MBV.CMS.HX.Api.Models;
using MBV.CMS.HX.Api.ViewModels;
using MBV.CMS.HX.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace MBV.CMS.HX.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route(RouteRoot)]
    public class MBCarsController : ControllerBase
    {
        private const string RouteRoot = "api/v{version:apiVersion}/mercedes-benz-cars";

        private readonly ILogger<MBCarsController> _logger;
        private readonly IMapper _mapper;
        private readonly IMBCarService _mBCarService;
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="mBCarService"></param>
        public MBCarsController(ILogger<MBCarsController> logger
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
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a Mercedes-Benz car.", Tags = new[] { "Mercedes-Benz Cars" })]
        [ProducesResponseType(typeof(MBCarResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> GetMBCarAsync([FromRoute] long id)
        {
            _logger.LogDebug("Entering to Mercedes-Benz cars controller -> GetMBCarAsync");

            var domainMBCar = await _mBCarService.GetMBCarAsync(id);
            if (domainMBCar is null)
                return NotFound();

            var viewModelMBCarResponse = _mapper.Map<MBCarResponse>(domainMBCar);

            return Ok(viewModelMBCarResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds a new Mercedes-Benz car.", Tags = new[] { "Mercedes-Benz Cars" })]
        [ProducesResponseType(typeof(MBCarResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> CreateMBCarAsync([FromBody] MBCarCreateRequest mBCarCreateRequest)
        {
            _logger.LogDebug("Entering to Mercedes-Benz cars controller -> CreateMBCarAsync");

            var domainMBCar = _mapper.Map<Domain.MBCar>(mBCarCreateRequest);
            var domainMBCarAdded = await _mBCarService.CreateMBCarAsync(domainMBCar);
            //throw new Exception("XXX");
            return Created($"{RouteRoot}/{domainMBCarAdded.Id}", _mapper.Map<MBCarResponse>(domainMBCarAdded));
        }

    }
}