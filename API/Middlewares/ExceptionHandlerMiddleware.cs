using System.Net;
using System.Text.Json;

namespace BusinessAPI.Api.Middlewares;

public class ExceptionHandlerMiddleware
{
  private readonly RequestDelegate _next;

  public ExceptionHandlerMiddleware(RequestDelegate next)
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
      await HandleExceptionAsync(context, ex);
    }
  }
  private static Task HandleExceptionAsync(HttpContext context, Exception exception)
  {
    context.Response.ContentType = "application/json";
    context.Response.StatusCode = exception.Data["StatusCode"] != null
      ? (int)(exception.Data["StatusCode"] ?? 500)
      : (int)HttpStatusCode.InternalServerError;

    var result = JsonSerializer.Serialize(new
    {
      Message = context.Response.StatusCode != 500 ? exception.Message : "Internal Server Error",
      Errors = exception.Data["Errors"] ?? null
    });

    return context.Response.WriteAsync(result);
  }
}