using N_TierArchitectureToDoApp.Core.Exceptions;
using N_TierArchitectureToDoApp.Core.GeneralModels;
using System.Net;

namespace N_TierArchitectureToDoApp.UI.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (HttpStatusCodeException ex)
            {
                context.Response.StatusCode = (int)ex.StatusCode;
                context.Response.ContentType = ex.ContentType;

                await context.Response.WriteAsync(new ErrorResultModel
                {
                    Title = "Warning",
                    Message = ex.Message,
                }.ToString());
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = @"application/json";

                await context.Response.WriteAsync(new ErrorResultModel
                {
                    Title = "Error",
                    Message = ex.Message,
                }.ToString());
            }
        }
    }
}
