using Microsoft.AspNetCore.Mvc;
using Project.Proxy;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;

namespace Project.FrontEnd.ViewComponents
{
    [ViewComponent(Name = "ProductInCategory")]
    public class ProductInCategoryComponent : ViewComponent
    {
        private readonly IProduct _product;
        public ProductInCategoryComponent(IProduct product)
        {
            _product = product;
        }

        public async Task<IViewComponentResult> InvokeAsync(int cateId, int page)
        {
            var  data = await _product.GetAllPagingProduct(page,9, cateId);

            return View(data);
        }
    }
}
