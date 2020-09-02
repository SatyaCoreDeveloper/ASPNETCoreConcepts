using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMiddleware.Middleware
{
    public static class NetSessionslogSensitivityExtension
    {
        public static IApplicationBuilder UseNetSessionLogSensitivity(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<NetSessionslogSensitivity>();
        }
    }
}
