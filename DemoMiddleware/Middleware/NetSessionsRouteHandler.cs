using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMiddleware.Middleware
{
    public class NetSessionsRouteHandler
    {
        private readonly RequestDelegate _next;

        public NetSessionsRouteHandler(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("NetSession Route Handler Middleware while request\n");
            var isRoot = (context.Request.Path.Value.Equals("/"));
            if (isRoot)
                await _next.Invoke(context);
            await context.Response.WriteAsync("NetSession Route Handler Middleware while response\n");            
        }
    }
}
