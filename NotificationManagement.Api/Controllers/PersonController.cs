using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using NotificationManagement.Api.Controllers;
using NotificationManagement.Domain.Application.Requests.Base;
using NotificationManagement.Domain.Application.Requests.Person;
using NotificationManagement.Domain.Application.Responses.Base;

namespace PersonManagement.Api.Controllers
{
    [Route("api/v1/person")]
    [ApiController]
    public class PersonController : BaseController
    {
        public PersonController(IMediator mediator) : base(mediator)
        {
        }
        /// <summary>
        /// Get Persons
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(OperationResponse), StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> Get([FromQuery] PaginationFilterRequest filter)
        {
            var operationRequest = new GetPersonRequest(filter);
            var operationResponse = await _mediator.Send(operationRequest);

            return TranslateResponse(operationResponse);
        }
    }
}
