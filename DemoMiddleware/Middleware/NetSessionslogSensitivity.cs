using DemoMiddleware.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMiddleware.Middleware
{
    public class NetSessionslogSensitivity
    {
        private readonly RequestDelegate _next;
        private readonly LogSensitivity _logSensitivity;
        private readonly IWebHostEnvironment _environment;

        public NetSessionslogSensitivity(RequestDelegate next, IOptions<LogSensitivity> option, IWebHostEnvironment environment)
        {
            _next = next;
            _logSensitivity = option.Value;
            _environment = environment;
        }

        public async Task Invoke(HttpContext context)
        {
            //Todo                       
            if (_environment.IsStaging())
            {
                _logSensitivity.logResponseStatus = false;
            }
            else if (_environment.IsProduction())
            {
                _logSensitivity.logResponses = false;
                _logSensitivity.logResponseStatus = true;
            }        
            await context.Response.WriteAsync($"Log Response:{ _logSensitivity.logResponses.ToString()}, Log Response Status:{_logSensitivity.logResponseStatus.ToString()}\n");
            await _next.Invoke(context);
        }
    }
}
