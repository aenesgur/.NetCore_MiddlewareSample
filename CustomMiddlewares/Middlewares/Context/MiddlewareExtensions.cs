using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewares.Middlewares.Context
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseNumberChecker(this IApplicationBuilder app)
        {
            return app.UseMiddleware<NumberCheckerMiddleware>();
        }
        public static IApplicationBuilder UseToLower(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ToLowerMiddleware>();
        }
    }
}
