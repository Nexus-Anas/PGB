using Serilog;
using System.Net;

namespace PGB.API.Middlewares;

public class GlobalExceptionHandlerMiddleware
{
    private readonly ILogger<GlobalExceptionHandlerMiddleware> _logger;
    private readonly RequestDelegate _request;

    public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger, RequestDelegate request)
    {
        _logger = logger;
        _request = request;
    }




    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _request(context);
        }
        catch (Exception ex)
        {
            var err_id = Guid.NewGuid();
            Log.Error(ex, $"{err_id} : {ex.Message}"); // log exception

            // Return custom error response
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Response.ContentType = "application/json";


            var error = new
            {
                Id = err_id,
                ErrorMessage = "Something went wrong! We're looking to resolve this."
            };
            await context.Response.WriteAsJsonAsync(error);
        }
    }
}