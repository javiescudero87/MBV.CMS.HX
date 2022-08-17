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
    public class ActionsController : ControllerBase
    {
        private const string RouteRoot = "api/v{version:apiVersion}/actions";

        private readonly ILogger<ActionsController> _logger;
        private readonly IMapper _mapper;
        private readonly ICreateActionToolService _actionService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="mBCarService"></param>
        public ActionsController(ILogger<ActionsController> logger
            , IMapper mapper
            , ICreateActionToolService actionService)
        {
            _logger = logger;
            _mapper = mapper;
            _actionService = actionService;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Adds a new action.", Tags = new[] { "Actions" })]
        [ProducesResponseType(typeof(ActionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> CreateActionAsync([FromBody] ActionCreateRequest actionCreateRequest)
        {
            _logger.LogDebug("Entering to Actions controller -> CreateActionAsync");

            var domainAction = _mapper.Map<Domain.CreateToolAction>(actionCreateRequest);
            var domainActionAdded = await _actionService.CreateCreateToolActionAsync(domainAction);
            return Created($"{RouteRoot}/{domainActionAdded.Id}", _mapper.Map<ActionResponse>(domainActionAdded));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/execute")]
        [SwaggerOperation(Summary = "Executes an action tool.", Tags = new[] { "Actions" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> ExecuteActionAsync([FromRoute] long id, [FromBody] ExecuteActionRequest executeActionRequest)
        {
            _logger.LogDebug("Entering to Actions controller -> ExecuteActionAsync");
            await _actionService.ExecuteAsync(id, executeActionRequest.ToolId, executeActionRequest.Location);
            return Ok();
        }
    }
}
