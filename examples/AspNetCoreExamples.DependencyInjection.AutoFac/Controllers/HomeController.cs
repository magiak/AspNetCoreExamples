using System.Diagnostics;
using Autofac.Features.AttributeFilters;
using Autofac.Features.Indexed;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreExamples.DependencyInjection.AutoFac.Controllers
{
    public class HomeController : Controller
    {
        //public HomeController(
        //    [KeyFilter("debug")]ILogging logger)
        //{
        //    var name1 = logger.GetType().Name;
        //    Debugger.Break();
        //}

        public HomeController(IIndex<string, ILogging> loggers)
        {
            var debugLogger = loggers["debug"];
            var defaultLogger = loggers["default"];
            Debugger.Break();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
