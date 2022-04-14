using MediatR;
using Microsoft.AspNetCore.Mvc;
using NotificationManagement.Domain.Application.Responses.Base;

namespace NotificationManagement.Api.Controllers
{
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected ActionResult TranslateResponse(OperationResponse operationResponse)
        {
            if (operationResponse.IsSuccess)
                return Ok(operationResponse);

            if (!operationResponse.IsSuccess)
                return UnprocessableEntity(operationResponse);

            return StatusCode(500, OperationResponse.Error("Internal Server Error"));

        }
    }
}
