using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExamples.Mvc.Controllers
{
    public class DockerComposeController : Controller
    {
        private readonly IHttpClientFactory factory;

        public DockerComposeController(IHttpClientFactory factory) // IHttpContextAccessor httpContextAccessor
        {
            this.factory = factory;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var httpClient = factory.CreateClient();
                var response = await httpClient.GetAsync("http://aspnetcoreexamples.webapi:80/WeatherForecast");

                if (!response.IsSuccessStatusCode)
                {
                    return this.BadRequest(response);
                }

                var content = await response.Content.ReadAsStringAsync();

                return this.Json(content);
            }
            catch(Exception ex)
            {
                return this.BadRequest();
            }
        }
    }
}