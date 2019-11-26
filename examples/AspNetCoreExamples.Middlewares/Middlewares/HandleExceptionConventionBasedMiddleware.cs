using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;

namespace AspNetCoreExamples.Middlewares.Middlewares
{
    public class HandleExceptionConventionBasedMiddleware
    {
        private readonly RequestDelegate next;

        public HandleExceptionConventionBasedMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context, IWebHostEnvironment environment)
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
