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
    public class Detail : IDetail
    {
        private readonly string _api;
        public Detail(string api)
        {
            _api = api;
        }
        public async Task<ProductViewModel> GetProductDetail(int productId)
        {
            var detail = new ProductViewModel();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/product/detail/{productId}";
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
