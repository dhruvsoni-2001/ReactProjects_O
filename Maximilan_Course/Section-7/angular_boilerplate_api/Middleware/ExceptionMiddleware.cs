using BoilerPlate.Response;
using Newtonsoft.Json;

namespace BoilerPlate.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = 500;

                CommonResponse<object?> response = new CommonResponse<object?>();
                response.Status = false;
                response.Error = new[] { ex.Message };
                response.Data = null;

                await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
            }
        }
    }

    
}
