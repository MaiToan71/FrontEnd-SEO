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

namespace Project.Proxy
{
    public class Product : IProduct
    {
        private readonly string _api;
        private readonly ICachingExtension _ICachingExtension;
        public Product(string api, ICachingExtension ICachingExtension)
        {
            _ICachingExtension = ICachingExtension;
            _api = api;
        }
        public async Task<ResponsePaging> GetAllPagingProduct(int page, int size)
        {
            var responsePaging = new ResponsePaging();
            var products = new List<ProductViewModel>();
            string cacheKey = $"GetAllPagingProduct_{page}_{size}";
            object cache_Payload;
            try
            {
                var hitCached = _ICachingExtension.TryGetCache(out cache_Payload, cacheKey);
                if (hitCached)
                {
                    var responseCache = JsonConvert.DeserializeObject<ResponsePaging>((string)cache_Payload);


                    return responseCache;
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/product?PageIndex={page}&PageSize={size}";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        foreach (var p in response.items)
                        {
                            List<ImageViewModel> productImages = new List<ImageViewModel>();
                            int productId = p.id;
                            string productName = p.title;
                            var product = new ProductViewModel()
                            {
                                Id = p.id,
                                Title = p.title,
                                DateCreated = p.dateCreated,
                                DateUpdated= p.dateUpdated,
                                Description = p.description,
                                SeoAlias = $"/{p.seoAlias}.html"
                            };
                            if (p.images != null)
                            {
                                foreach (var pimg in p.images)
                                {
                                    productImages.Add(new ImageViewModel()
                                    {
                                        Id = pimg.id,
                                        Name = pimg.caption,
                                        Path = $"{_api}{pimg.imagePath}",
                                    });
                                    productImages.Add(pimg);
                                }
                                product.Images = productImages;
                            }
                            products.Add(product);

                        }
                        responsePaging.Total = response.totalRecord;
                        responsePaging.Data = products;
                    }


                    string dataJson = JsonConvert.SerializeObject(responsePaging);
                    _ICachingExtension.SetCache(cacheKey, dataJson, 1 * 60);
                    return responsePaging;

                }
            }
            catch (Exception ex)
            {

                return responsePaging;
            }
        }
    }
}
