using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Services.Configurations
{
    public class RequestResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public RequestResponseLoggingMiddleware(RequestDelegate next, ILogger<RequestResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log the request details.
            _logger.LogInformation($"Request: {context.Request.Method} {context.Request.Path}");

            // Log the request body (optional).
            if (context.Request.Body != null)
            {
                context.Request.EnableBuffering();
                var requestBodyStream = new StreamReader(context.Request.Body, encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false, bufferSize: 1024, leaveOpen: true);
                var requestBody = await requestBodyStream.ReadToEndAsync();
                context.Request.Body.Position = 0;

                _logger.LogInformation($"Request Body: {requestBody}");
            }

            // Let the request move on in the pipeline.
            await _next(context);

            // Log the response details.
            _logger.LogInformation($"Response: {context.Response.StatusCode}");
        }
    }
}
