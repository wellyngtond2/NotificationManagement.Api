using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationManagement.Domain.Application.Requests.NotificationTemplate;
using NotificationManagement.Domain.Application.Responses.Base;
using System.Threading.Tasks;

namespace NotificationManagement.Api.Controllers
{
    [Route("api/v1/notification-templates")]
    [ApiController]
    public class NotificationTemplateController : BaseController
    {
        public NotificationTemplateController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Create a new Notification Template
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create([FromBody] NotificationTemplateRequest request)
        {
            var operationRequest = new CreateNotificationTemplateRequest(request);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }

        /// <summary>
        /// Update a Notification Template
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{Id}")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Update(int Id, [FromBody] NotificationTemplateRequest request)
        {
            var operationRequest = new UpdateNotificationTemplateRequest(Id, request);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }


        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get([FromQuery] GetNotificationTemplateFilterRequest filter)
        {
            var operationRequest = new GetNotificationTemplateRequest(filter);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }
    }
}
