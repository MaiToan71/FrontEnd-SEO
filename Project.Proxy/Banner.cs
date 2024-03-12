using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy
{
    public class Banner : IBanner
    {
        private readonly string _api;
        public Banner(string api)
        {
            _api = api;
        }
        public async Task<List<BannerViewModel>> GetHomeBanner()
        {
            List<BannerViewModel> array = new List<BannerViewModel>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/home/banners";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        foreach (var i in response)
                        {
                            var newObj = new BannerViewModel
                            {
                                Id = i.id,
                                Name = i.caption,
                                Path =$"{_api}{i.imagePath}",
                            };
                            array.Add(newObj);
                        }
                    }


                    return array;

                }
            }
            catch (Exception ex)
            {

                return array;
            }
        }
    }
}
