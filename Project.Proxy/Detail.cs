using Newtonsoft.Json;
using Project.Caching.Interfaces;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project.Proxy
{
    public class Detail : IDetail
    {
        private readonly string _api;
        private readonly ICachingExtension _ICachingExtension;
        public Detail(string api, ICachingExtension ICachingExtension)
        {
            _api = api;
            _ICachingExtension = ICachingExtension;
        }
        public async Task<ProductViewModel> GetProductDetail(string slug)
        {
            var detail = new ProductViewModel();
            try
            {
                string cacheKey = $"GetProductDetail_{slug}";
                object cache_Payload;
                var hitCached = _ICachingExtension.TryGetCache(out cache_Payload, cacheKey);
                if (hitCached)
                {
                    var responseCache = JsonConvert.DeserializeObject<ProductViewModel>((string)cache_Payload);


                    return responseCache;
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/product/detail/{slug}";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();

                        detail.Title = response.title;
                        detail.Body = response.body;
                        detail.DateCreated = response.dateCreated;
                        detail.Description = response.description;
                        detail.ViewCount = response.viewCount;
                    }

                    string dataJson = JsonConvert.SerializeObject(detail);
                    _ICachingExtension.SetCache(cacheKey, dataJson, 1 * 60);

                    return detail;

                }
            }
            catch (Exception ex)
            {

                return detail;
            }
        }
    }
}
