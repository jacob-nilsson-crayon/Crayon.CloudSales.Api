using Microsoft.AspNetCore.Diagnostics;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Crayon.CloudSales.Api.ExceptionHandler
{
    public class CrayonCloudSalesExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<CrayonCloudSalesExceptionHandler> _logger;

        public CrayonCloudSalesExceptionHandler(ILogger<CrayonCloudSalesExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            _logger.LogError($"Exception occured: {exception.Message}");

            HttpStatusCode statusCode;
            string title;

            switch (exception)
            {
                case KeyNotFoundException:
                    statusCode = HttpStatusCode.NotFound;
                    title = "Item not found";
                    break;
                case ValidationException:
                    statusCode = HttpStatusCode.BadRequest;
                    title = "Invalid requet data";
                    break;
                default:
                    statusCode = HttpStatusCode.InternalServerError;
                    title = "Internal Server Error";
                    break;
            }

            var errorResponse = new
            {
                StatusCode = statusCode,
                Title = title,
                Message = exception.Message
            };

            httpContext.Response.StatusCode = (int)statusCode;

            await httpContext.Response.WriteAsJsonAsync(errorResponse, cancellationToken);

            return true;
        }
    }
}
