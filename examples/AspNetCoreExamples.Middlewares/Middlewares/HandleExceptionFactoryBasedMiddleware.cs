using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace AspNetCoreExamples.Middlewares.Middlewares
{
    public class HandleExceptionFactoryBasedMiddleware : IMiddleware
    {
        private readonly IWebHostEnvironment environment;

        public HandleExceptionFactoryBasedMiddleware(IWebHostEnvironment environment)
        {
            this.environment = environment;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch(Exception ex)
            {
                if (environment.IsDevelopment())
                {
                    await context.Response.WriteAsync($"Error occured: {ex.Message}");
                }
                else
                {
                    await context.Response.WriteAsync("Unexpected error occured!");
                }
            }
        }
    }
}
