using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;

namespace Project.FrontEnd.ViewComponents
{
   
    [ViewComponent(Name = "ProductHot")]
    public class ProductHotViewComponent : ViewComponent
    {
        private readonly IHot _hot;
        public ProductHotViewComponent(IHot hot)
        {
            _hot = hot;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<ProductViewModel> data = await _hot.GetHot();
           
            return View(data);
        }
    }
}
