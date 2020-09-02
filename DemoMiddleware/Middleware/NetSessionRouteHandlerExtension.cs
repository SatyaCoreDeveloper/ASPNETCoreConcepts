using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMiddleware.Middleware
{
    public static class NetSessionRouteHandlerExtension
    {
        public static IApplicationBuilder UseNetSessionsRouteHandler(this IApplicationBuilder application)
        {
            return application.UseMiddleware<NetSessionsRouteHandler>();
        }
    }
}
