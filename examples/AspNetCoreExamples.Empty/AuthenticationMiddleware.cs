using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace AspNetCoreExamples.Lab
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;
        private const string token = "my-secret-token";

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string key = "Authorization";
            string value = null;
            if (context.Request.Headers.ContainsKey(key))
            {
                value = context.Request.Headers[key];
            }

            if (context.Request.Query.ContainsKey(key))
            {
                value = context.Request.Query[key];
            }

            if (value == token)
            {
                await next(context);
                return;
            }

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            await context.Response.WriteAsync("You are not authorized to access the page.");
        }
    }
}
