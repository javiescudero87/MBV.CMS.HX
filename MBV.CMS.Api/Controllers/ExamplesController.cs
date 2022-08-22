using AutoMapper;
using MBV.CMS.Api.Models;
using MBV.CMS.Api.ViewModels;
using MBV.CMS.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace MBV.CMS.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route(RouteRoot)]
    public class ExamplesController : ControllerBase
    {
        private const string RouteRoot = "api/v{version:apiVersion}/mercedes-benz-cars";

        private readonly ILogger<ExamplesController> _logger;
        private readonly IMapper _mapper;
        private readonly IExampleService _exampleService;
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="exampleService"></param>
        public ExamplesController(ILogger<ExamplesController> logger
            , IMapper mapper
            , IExampleService exampleService)
        {
            _logger = logger;
            _mapper = mapper;
            _exampleService = exampleService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a Mercedes-Benz car.", Tags = new[] { "Mercedes-Benz Cars" })]
        [ProducesResponseType(typeof(ExampleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status404NotFound)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> GetExampleAsync([FromRoute] long id)
        {
            _logger.LogDebug("Entering to Mercedes-Benz cars controller -> GetExampleAsync");

            var domainExample = await _exampleService.GetExampleAsync(id);
            if (domainExample is null)
                return NotFound();

            var viewModelExampleResponse = _mapper.Map<ExampleResponse>(domainExample);

            return Ok(viewModelExampleResponse);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds a new Mercedes-Benz car.", Tags = new[] { "Mercedes-Benz Cars" })]
        [ProducesResponseType(typeof(ExampleResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> CreateExampleAsync([FromBody] ExampleCreateRequest exampleCreateRequest)
        {
            _logger.LogDebug("Entering to Mercedes-Benz cars controller -> CreateExampleAsync");

            var domainExample = _mapper.Map<Domain.ExampleEntity>(exampleCreateRequest);
            var domainExampleAdded = await _exampleService.CreateExampleAsync(domainExample);
            return Created($"{RouteRoot}/{domainExampleAdded.Id}", _mapper.Map<ExampleResponse>(domainExampleAdded));
        }

    }
}