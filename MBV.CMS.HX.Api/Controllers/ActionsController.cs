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
        private readonly IToolActionService _actionService;


        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mapper"></param>
        /// <param name="mBCarService"></param>
        public ActionsController(ILogger<ActionsController> logger
            , IMapper mapper
            , IToolActionService actionService)
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
        [SwaggerOperation(Summary = "Adds a new incorporation action.", Tags = new[] { "Actions" })]
        [ProducesResponseType(typeof(IncorporationActionResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> IncorporationActionAsync([FromBody] IncorporationActionRequest incorporationActionRequest)
        {
            _logger.LogDebug("Entering to Actions controller -> IncorporationActionAsync");

            var domainAction = _mapper.Map<Domain.IncorporationToolAction>(incorporationActionRequest);
            var domainActionAdded = await _actionService.CreateToolActionAsync<Domain.IncorporationToolAction>(domainAction);
            return Created($"{RouteRoot}/{domainActionAdded.Id}", _mapper.Map<IncorporationActionResponse>(domainActionAdded));
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
        public async Task<IActionResult> IncorporationActionAsync([FromRoute] long id, [FromBody] ExecuteActionRequest executeActionRequest)
        {
            _logger.LogDebug("Entering to Actions controller -> IncorporationActionAsync");
            var domainAction = _mapper.Map<Domain.IncorporationToolAction>(executeActionRequest);
            domainAction.Id = id;
            await _actionService.ExecuteAsync(domainAction);
            return Ok();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("{id}/verify")]
        [SwaggerOperation(Summary = "Verifies and action tool.", Tags = new[] { "Actions" })]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorDetailModel), StatusCodes.Status400BadRequest)]
        [Produces(MediaTypeNames.Application.Json, "application/problem+json")]
        public async Task<IActionResult> VerifyActionAsync([FromRoute] long id, [FromBody] VerifyActionRequest verifyActionRequest)
        {
            _logger.LogDebug("Entering to Actions controller -> VerifyActionAsync");
            await _actionService.VerifyAsync(id, verifyActionRequest.Evidence);
            return Ok();
        }

    }
}
