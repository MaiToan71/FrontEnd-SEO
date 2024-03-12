using Microsoft.AspNetCore.Mvc;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;

namespace Project.FrontEnd.ViewComponents
{
    [ViewComponent(Name = "HomeBanner")]
    public class HomeBannerViewComponent: ViewComponent
    {
        private readonly IBanner _banner;
        public HomeBannerViewComponent(IBanner banner)
        {
            _banner = banner;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<BannerViewModel> data = await _banner.GetHomeBanner();
            try
            {
            }
            catch (Exception ex)
            {
            }
            return View(data);
        }
    }
}
