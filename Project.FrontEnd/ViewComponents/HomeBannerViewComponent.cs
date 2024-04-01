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
            List<BannerViewModel> data;
            try
            {
                data = await _banner.GetHomeBanner();
            }
            catch (Exception ex)
            {
                data = new List<BannerViewModel>();
            }
            return View(data);
        }
    }
}
