using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;

namespace Project.FrontEnd.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        public CategoryController(ICategory category)
        {
            _category = category;
        }

        [Route("danh-muc/{slug}-{id}")]
        public async Task<IActionResult> Index(string slug, int id)
        {
            var data = await _category.GetCategory(id);
            return View(data);
        }
    }
}
