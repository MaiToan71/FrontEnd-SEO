using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;

namespace Project.FrontEnd.ViewComponents
{

    [ViewComponent(Name = "CategoryHot")]
    public class CategoryHotComponent : ViewComponent
    {
        private readonly IHot _hot;
        public CategoryHotComponent(IHot hot)
        {
            _hot = hot;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<CategoryOutstandViewModel> data = await _hot.GetCategoryHot();
            return View(data);
        }
    }
}
