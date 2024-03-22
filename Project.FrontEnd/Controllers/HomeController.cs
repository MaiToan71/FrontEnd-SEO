using DotnetSitemapGenerator;
using Microsoft.AspNetCore.Mvc;
using Project.FrontEnd.Models;
using Project.FrontEnd.Sitemaps;
using System.Diagnostics;

namespace Project.FrontEnd.Controllers
{
  

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }

       

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    public class ControllerSitemapAttribute : SitemapAttribute
    {
    }

    public class ActionSitemapAttribute : SitemapAttribute
    {
        public ActionSitemapAttribute()
        {
            ChangeFrequency = DotnetSitemapGenerator.ChangeFrequency.Daily;
            Priority = 0.9m;
        }
    }
}
