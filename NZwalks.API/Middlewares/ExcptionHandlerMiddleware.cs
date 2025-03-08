using System.Net;

namespace NZwalks.API.Middlewares
{
    public class ExcptionHandlerMiddleware(ILogger<ExcptionHandlerMiddleware> logger, RequestDelegate next)
    {

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                var errorId = Guid.NewGuid();

                //log this exception
                logger.LogError(ex, $"{errorId} : {ex.Message}" );

               //return custom error
               httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                httpContext.Response.ContentType = "application/json";

                var error = new
                {
                    Id = errorId,
                   ErrorMessage = "Somting went wrong ! We are looking into resolving this."
                };
                await httpContext.Response.WriteAsJsonAsync(error);
            }
        }
    }

}