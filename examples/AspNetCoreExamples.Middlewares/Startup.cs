using AspNetCoreExamples.ClassLibrary.Weather;
using AspNetCoreExamples.Middlewares.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Primitives;
using System;
using System.Text.Json;

namespace AspNetCoreExamples.Middlewares
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IWeatherForcastService, WeatherForcastService>();

            services.AddTransient<HandleExceptionFactoryBasedMiddleware>(); // register factory based middleware (implements IMiddleware)
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) // using Microsoft.Extensions.Hosting;
            {
                app.UseDeveloperExceptionPage();
            }

            // 1.
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            // 2.
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //    await next();
            //});

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World from next()!");
            });

            // 3.
            //app.UseWelcomePage("/welcomepage");

            // 4.
            app.Map("/map/example", applicationBuilder =>
            {
                // Use any middleware
                // c.UseMiddleware<>();
                // c.Run();
                // c.Use();

                applicationBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("Map example called!");
                });
            });

            // 5.
            //app.MapWhen((context) => context.Request.Path.StartsWithSegments("/map"), applicationBuilder => // /map/anything (internally using MapWhenMiddleware) :D
            //{
            //    applicationBuilder.Run(async (context) =>
            //    {
            //        await context.Response.WriteAsync("MapWhen example called!");
            //    });
            //});

            // 6. https://localhost:44327/test/path?query=1&query=2&sort=desc
            app.Run(async (context) =>
            {
                const string headerKey = "my-header-key";
                var features = context.Features; // IHttpRequestFeature, IHttpAuthenticationFeature, ... (about 11 mostly Http features)

                // Request
                var path = context.Request.Path; // -> /test/path
                var query = context.Request.Query; // returns QueryCollection
                var queryString = context.Request.QueryString; // -> ?query=1&query=2&sort=desc
                if (context.Request.ContentType != null)
                {
                    var form = context.Request.Form;
                    var formCollection = await context.Request.ReadFormAsync();
                }
                var headers = context.Request.GetTypedHeaders();
                var stringValues = context.Request.Headers["headerKey"]; // StringValues - multiple values with same key are allowed, implicit conversion to string
                var value = headers.Get<string>(headerKey);
                var body = context.Request.Body;
                var routeValues = context.Request.RouteValues;

                // Request Content
                var contentLength = context.Request.ContentLength;
                var contentType = context.Request.ContentType;

                // Response
                context.Response.StatusCode = StatusCodes.Status200OK;
                context.Response.ContentType = "application/json";

                if (!context.Response.Headers.ContainsKey(headerKey))
                {
                    context.Response.Headers.Add(headerKey, new StringValues(new[] { "value1", "value2", "value3" }));
                }

                var weather = context.Request.HttpContext.RequestServices.GetService<IWeatherForcastService>(); // GetRequiredService can throw an exception
                var serialized = JsonSerializer.Serialize(weather.GetCurrent());
                await context.Response.WriteAsync(serialized);

                context.Response.Cookies.Append("myCookie", "myCookieValue");

                context.Request.HttpContext.GetEndpoint();

                // and others ...
                // context.Response.SendFileAsync();
            });

            // 7.
            //app.Run(async (context) =>
            //{
            //    context.Response.Redirect("http://google.com/");
            //});

            // 9. try to use with and without app.UseDeveloperExceptionPage();
            //app.Run(async (context) =>
            //{
            //    throw new Exception("My exception!!!");
            //});

            // 10.
            app.UseMiddleware<HandleExceptionFactoryBasedMiddleware>();

            app.Run(async (context) =>
            {
                throw new Exception("My exception!!!");
            });

            // 11. examples
            // UseDeveloperExceptionPage https://github.com/aspnet/AspNetCore/blob/master/src/Middleware/Diagnostics/src/DeveloperExceptionPage/DeveloperExceptionPageMiddleware.cs
            //public async Task Invoke(HttpContext context)
            //{
            //    try
            //    {
            //        await _next(context);
            //    }
            //    catch (Exception ex)
            //    {
            //       ... handle exception and show error page
            //    }
            //}
        }
    }
}
