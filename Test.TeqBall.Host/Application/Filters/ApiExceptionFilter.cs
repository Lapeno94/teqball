using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace Test.TeqBall.Host.Application.Filters
{
    public class ApiExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<ApiExceptionFilter> _logger;

        public ApiExceptionFilter(ILogger<ApiExceptionFilter> logger)
        {
           _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = 500;
            context.Result = new ObjectResult(context)
            {
                StatusCode = StatusCodes.Status500InternalServerError,
                Value = context.RouteData
            };
            context.ExceptionHandled = true;

            _logger.LogError("Controller error", context);
        }
    }
}
