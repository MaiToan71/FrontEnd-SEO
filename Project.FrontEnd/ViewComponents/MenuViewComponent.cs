using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;

namespace Project.FrontEnd.ViewComponents
{
    [ViewComponent(Name = "Menu")]
    public class MenuViewComponent: ViewComponent
    {
        private readonly IMenu _menu;
        public MenuViewComponent(IMenu menu)
        {
            _menu = menu;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<MenuViewModel> menus = await _menu.GetAll();
            try
            {
            }
            catch (Exception ex)
            {
            }
            return View(menus);
        }
    }
}
