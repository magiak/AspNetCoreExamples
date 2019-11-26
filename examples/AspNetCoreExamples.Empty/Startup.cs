using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreExamples.Lab;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCoreExamples.Empty
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseMiddleware<AuthenticationMiddleware>();

            app.Map("/yesterday", applicationBuilder =>
            {
                applicationBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"Včera bylo {DateTime.Today.AddDays(-1).ToShortDateString()}");
                });
            });

            app.Run(async (context) =>
            {
                var currentPage = context.Request.Path;
                await context.Response.WriteAsync($"Dnes je {DateTime.Today.ToShortDateString()}");
            });
        }
    }
}
