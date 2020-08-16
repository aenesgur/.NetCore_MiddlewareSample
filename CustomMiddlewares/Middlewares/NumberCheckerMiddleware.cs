using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomMiddlewares.Middlewares
{
    public class NumberCheckerMiddleware
    {
        private readonly RequestDelegate _next;
        public NumberCheckerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("1. Middleware started \n");
            if (context.Request.Path == "/products")
            {
                var value = context.Request.Query["category"].ToString();
                if (!string.IsNullOrEmpty(value))
                {
                    if (int.TryParse(value, out int intValue))
                    {
                        await context.Response.WriteAsync($"category sayısal ifade olamaz: {intValue} \n");
                    }
                    else
                    {
                        context.Items["value"] = value; //programın ilerleyen aşamalarında kullanabileceğimiz bir collection oluşturduk
                        await _next(context);
                    }
                }
                else
                {
                    await context.Response.WriteAsync(" product list \n");
                }
            }
            else
            {
                
                await _next(context);
                
            }
            await context.Response.WriteAsync("1. Middleware finished\n");
        }
    }
}
