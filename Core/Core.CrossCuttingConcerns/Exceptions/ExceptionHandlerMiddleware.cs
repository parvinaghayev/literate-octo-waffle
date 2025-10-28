using System.Diagnostics.CodeAnalysis;
using Core.CrossCuttingConcerns.Exceptions.Handlers;
using Core.CrossCuttingConcerns.Extensions;
using Core.CrossCuttingConcerns.Logging.Commons;
using Core.CrossCuttingConcerns.Logging.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace Core.CrossCuttingConcerns.Exceptions;

public class ExceptionHandlerMiddleware
{
    private readonly RequestDelegate _next;

    private readonly ExceptionHandler _exceptionHandler;

    // private readonly ILogger _logger;
    private readonly IWebHostEnvironment _env;

    public ExceptionHandlerMiddleware(RequestDelegate next, ExceptionHandler exceptionHandler,
        // ILogger logger,
        IWebHostEnvironment env)
    {
        _next = next;
        _exceptionHandler = exceptionHandler;
        // _logger = logger;
        _env = env;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // string correlationId = Guid.NewGuid().ToString();
        // var originalBodyStream = context.Response.Body;
        try
        {
            // await OnBefore(context, correlationId);
            await _next.Invoke(context);
            // await OnAfter(context, correlationId, originalBodyStream);
        }
        catch (Exception exception)
        {
            var sentryEventId = SentrySdk.CaptureException(exception).ToString();

            context.Response.ContentType = "application/json";
            await _exceptionHandler.HandleException(exception, context);

            // await OnException(context, correlationId, originalBodyStream, sentryEventId);
        }
    }

    // public async Task OnBefore(HttpContext context, string correlationId)
    // {
    //     LogModel log = await CreateLogModel(context, "Start log", correlationId);
    //
    //     if (!_env.IsLocal())
    //         await _logger.Information(log);
    //     context.Response.ClearBody();
    // }
    // public async Task OnAfter(HttpContext context, string correlationId, Stream originalBodyStream)
    // {
    //     LogModel log = await CreateLogModel(context, "End log", correlationId);
    //     log.Response = await context.Response.CopyAndReplaceBody(originalBodyStream);
    //
    //     if (_env.IsLocal()) return;
    //     await _logger.Information(log);
    // }
    // public async Task OnException(HttpContext context, string correlationId, Stream originalBodyStream,
    //     string sentryEventId)
    // {
    //     LogModel log = await CreateLogModel(context, "End log", correlationId);
    //     log.SentryEventId = sentryEventId;
    //     log.Response = await context.Response.CopyAndReplaceBody(originalBodyStream);
    //
    //     if (_env.IsLocal()) return;
    //     await _logger.Error(log);
    // }

    // public async Task<LogModel> CreateLogModel(HttpContext context, string message, string requestCorrelationId)
    // {
    //     LogModel log = new();
    //     log.RequestCorrelationId = requestCorrelationId;
    //     log.Action = context.Request.RouteValues["action"] as string;
    //     log.Controller = context.Request.RouteValues["controller"] as string;
    //     context.Request.EnableBuffering();
    //     var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
    //     context.Request.Body.Seek(0, SeekOrigin.Begin);
    //
    //     log.Body = body;
    //     context.Request.Headers.Select(h => $"{h.Key}: {h.Value} \n").ToList().ForEach(h => log.Header += h);
    //
    //     //log.Header = context.Request.RouteValues["header"] as string;
    //     log.IPAddress = context.Connection.RemoteIpAddress.ToString();
    //     log.Url = context.Request.Path;
    //     log.UserProfileId = context.User?.FindFirst("userProfileId")?.Value;
    //     log.CreateDate = DateTime.UtcNow;
    //     log.Message = message;
    //
    //     if (context.User.FindFirst("userProfileList") is not null)
    //     {
    //         JArray jsonArray = JArray.Parse(context.User.FindFirst("userProfileList").Value);
    //         JObject jsonObject = (JObject)jsonArray[0];
    //         log.UserFullName = (string)jsonObject["Name"];
    //     }
    //
    //     return log;
    // }
}