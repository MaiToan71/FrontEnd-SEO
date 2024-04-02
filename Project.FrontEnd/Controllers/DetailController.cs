using Microsoft.AspNetCore.Mvc;
using Project.Proxy;
using Project.Proxy.Interfaces;

namespace Project.FrontEnd.Controllers
{
    public class DetailController : Controller
    {
        private readonly IDetail _detail;
        public DetailController(IDetail detail)
        {
            _detail = detail;
        }
        [ResponseCache(CacheProfileName = "Default300")]
        [Route("{slug}.html")]
        public async Task<IActionResult> Index(string slug)
        {
            var data = await _detail.GetProductDetail(slug);
            return View(data);
        }
    }
}
