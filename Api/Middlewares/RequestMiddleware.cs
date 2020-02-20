﻿using System;
using System.IO;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BoilerplateDotnetCorePostgres.Middlewares
{
    public class RequestMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestMiddleware> _logger;
        private readonly IConfiguration _configuration;

        // Must have constructor with this signature, otherwise exception at run time
        public RequestMiddleware(RequestDelegate next, ILogger<RequestMiddleware> logger, IConfiguration configuration)
        {
            // This is an HTTP Handler, so no need to store next
            _next = next;

            _logger = logger;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context)
        {
            bool hasError = false;
            bool logRequestContent = false;

            string requestContent = string.Empty;
            var ip = string.Empty;

            Stream originalBody = context.Response.Body;

            try
            {
                //get we really need to log request content or not from appSettings
                var setting = _configuration["Logging:LogRequestContent"];
               
                logRequestContent = setting != null && setting.ToLower() == "true";

                if (logRequestContent)
                {
                    var address = context.Request.HttpContext.Connection.RemoteIpAddress;
                    ip = address?.ToString();

                    var sr = new StreamReader(context.Request.Body);

                    var request = context.Request.Body;

                    var result = new byte[request.Length];

                    await request.ReadAsync(result, 0, (int)request.Length);

                    requestContent = System.Text.Encoding.ASCII.GetString(result);

                    context.Request.Body.Position = 0;
                }

                await _next(context);
            }
            catch (Exception exc)
            {
                hasError = true;
                context.Response.Clear();
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(ErrorMessage.ApplicationExceptionMessage);

                //log service exc
                _logger.LogError(exc, "Unhandled error", null);
            }
            finally
            {
                if (!hasError)
                {
                    context.Response.Body = originalBody;
                }

                if (logRequestContent)
                {
                    ProcessMessageAsync(context.Response.StatusCode, requestContent, ip);
                }
            }
        }

        /// <summary>
        /// saves req and resp async
        /// </summary>
        /// <param name="responseStatusCode"></param>
        /// <param name="requestContent"></param>
        /// <param name="url"></param>
        /// <param name="ip"></param>
        private void ProcessMessageAsync(int responseStatusCode, string requestContent, string ip)
        {
            //trim requestContent as max 500 char variable
            var content = string.IsNullOrEmpty(requestContent)
                ? null
                : requestContent.Length >= 500 ? requestContent.Substring(0, 500) : requestContent;

            var logContent = string.Format("ip: {0}|status: {1}|req: {2}", ip, responseStatusCode, content);

            _logger.LogInformation(logContent);
        }

    }

    public static class RequestMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestMiddleware>();
        }
    }

}