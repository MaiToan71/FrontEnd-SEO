using Microsoft.AspNetCore.Mvc;

namespace Project.FrontEnd.Controllers
{
    public class IPController : Controller
    {
        private readonly ILogger<IPController> _logger;
        public IPController( ILogger<IPController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()

        {
            string ip = HttpContext.GetRemoteIPAddress().ToString();
            _logger.LogInformation($"{ip}");
            
            return View();
        }
    }
}
