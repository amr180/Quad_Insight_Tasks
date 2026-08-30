using System.Net;
using System.Text.Json;

namespace TaskManagement.API.Middleware;

public class GlobalExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<GlobalExceptionMiddleware> _logger;

    public GlobalExceptionMiddleware(
        RequestDelegate next,
        ILogger<GlobalExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (KeyNotFoundException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.NotFound,
                ex.Message);
        }
        catch (ArgumentException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.BadRequest,
                ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            await HandleExceptionAsync(
                context,
                HttpStatusCode.BadRequest,
                ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(
                ex,
                "An unexpected error occurred.");

            await HandleExceptionAsync(
                context,
                HttpStatusCode.InternalServerError,
                "An unexpected error occurred.");
        }
    }

    private static async Task HandleExceptionAsync(
        HttpContext context,
        HttpStatusCode statusCode,
        string message)
    {
        context.Response.ContentType =
            "application/json";

        context.Response.StatusCode =
            (int)statusCode;

        var response = new
        {
            statusCode = (int)statusCode,
            message
        };

        await context.Response.WriteAsync(
            JsonSerializer.Serialize(response));
    }
}