using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using NotificationManagement.Domain.Application.Responses.Base;
using System;
using System.Linq;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace NotificationManagement.Api.Filters
{
    public class ApiExceptionsFilters : IExceptionFilter
    {
        private readonly ILogger _logger;

        public ApiExceptionsFilters(ILogger logger)
        {
            _logger = logger;
        }
        public void OnException(ExceptionContext context)
        {
            context.ExceptionHandled = true;
            Exception exception = context.Exception;

            if (context.Exception is ValidationException)
            {
                _logger.LogInformation(exception, exception.Message);

                var mgs = (exception as ValidationException).Errors.Select(err => err.ErrorMessage);

                var response = OperationResponse.Error(String.Join(", ", mgs.ToArray()));

                context.Result = new JsonResult(response) { StatusCode = 400 };
            }
            else
            {
                _logger.LogError(exception, exception.Message);

                var response = OperationResponse.Error("Unexpected Error");

                context.Result = new JsonResult(response) { StatusCode = 500 };
            }
        }
    }
}