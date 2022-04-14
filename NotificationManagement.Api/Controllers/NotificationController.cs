using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NotificationManagement.Domain.Application.Requests.Notification;
using NotificationManagement.Domain.Application.Responses.Base;
using System.Threading.Tasks;

namespace NotificationManagement.Api.Controllers
{
    [Route("api/v1/notifications")]
    [ApiController]
    public class NotificationController : BaseController
    {
        public NotificationController(IMediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// Create a new Notification 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Create([FromBody] NotificationRequest request)
        {
            var operationRequest = new CreateNotificationRequest(request);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }

        /// <summary>
        /// Update a Notification 
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
        public async Task<ActionResult> Update(int Id, [FromBody] NotificationRequest request)
        {
            var operationRequest = new UpdateNotificationRequest(Id, request);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }

        /// <summary>
        /// Send UnSent notifications
        /// </summary>
        /// <returns></returns>
        [HttpPost("send")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> SendNotifications()
        {
            var operationRequest = new SendNotificationRequest();
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }

        /// <summary>
        /// Return a Notification collection
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get([FromQuery] GetNotificationFilterRequest filter)
        {
            var operationRequest = new GetNotificationRequest(filter);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }


        /// <summary>
        /// Return a Notification totals
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet("get-totals")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> GetTotals()
        {
            var operationRequest = new GetNotificationTotalsRequest();
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }
    }
}
