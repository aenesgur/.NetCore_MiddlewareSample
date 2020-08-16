using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewares.Middlewares
{
    public class ToLowerMiddleware
    {
        private readonly RequestDelegate _next;
        public ToLowerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("2. Middleware started \n");
            if (context.Items["value"] != null)
            {
                var value = context.Items["value"].ToString();
                context.Items["value"] = value.ToLower();
            }

            await _next(context);
            await context.Response.WriteAsync("2. Middleware finished \n");
        }
    }
}
