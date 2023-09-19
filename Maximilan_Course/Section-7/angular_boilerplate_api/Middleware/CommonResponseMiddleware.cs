using BoilerPlate.Response;
using Newtonsoft.Json;

public class CommonResponseMiddleware
{
    private readonly RequestDelegate _next;
    private readonly JsonSerializerSettings _settings;

    public CommonResponseMiddleware(RequestDelegate next, JsonSerializerSettings settings)
    {
        _next = next;
        _settings = settings;
    }
    public async Task InvokeAsync(HttpContext context)
    {

        var currentBody = context.Response.Body;
        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        await _next(context);

        context.Response.Body = currentBody;

        memoryStream.Seek(0, SeekOrigin.Begin);

        var readToEnd = new StreamReader(memoryStream).ReadToEnd();
        try
        {
            var result = JsonConvert.DeserializeObject<CommonResponse<object?>>(readToEnd);

            if (result?.Error != null || result?.Data != null)
            {
                await context.Response.WriteAsync(JsonConvert.SerializeObject(result, _settings));
                return;
            }
        }
        catch (Exception)
        {

        }

        var response = new CommonResponse<object>() { Data = JsonConvert.DeserializeObject<object>(readToEnd) };
        await context.Response.WriteAsync(JsonConvert.SerializeObject(response, _settings));
    }
}
