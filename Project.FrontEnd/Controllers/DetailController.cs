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
        [Route("{slug}-{id}")]
        public async Task<IActionResult> Index(string slug, int id)
        {
            var data = await _detail.GetProductDetail(id);
            return View(data);
        }
    }
}
