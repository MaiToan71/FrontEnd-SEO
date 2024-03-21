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
    public class Category : ICategory
    {
        private readonly string _api;
        private readonly ICachingExtension _ICachingExtension;
        public Category(string api, ICachingExtension ICachingExtension)
        {
            _api = api;
            _ICachingExtension = ICachingExtension;
        }
        public async Task<CategoryViewModel> GetCategory(int id)
        {
            var category = new CategoryViewModel();
            string cacheKey = $"GetCategory_{id}";
            object cache_Payload;
            try
            {
                var hitCached = _ICachingExtension.TryGetCache(out cache_Payload, cacheKey);
                if (hitCached)
                {
                    var responseCache = JsonConvert.DeserializeObject<CategoryViewModel>((string)cache_Payload);


                    return responseCache;
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/category/{id}";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        List<ImageViewModel> images = new List<ImageViewModel>();
                        List<ProductViewModel> products = new List<ProductViewModel>();
                        category.Name = response.name;
                        category.Description = response.description;
                        category.Body = response.note;
                        foreach(var i in response.banners)
                        {
                            var newImage = new ImageViewModel()
                            {
                                Id = i.id,
                                Name = i.caption,
                                Path = i.imagePath
                            };
                            images.Add(newImage);
                        }
                        category.Images = images;
                        foreach(var p in response.products)
                        {
                            List<ImageViewModel> productImages = new List<ImageViewModel>();
                            int productId = p.id;
                            string productName = p.title;
                            var product = new ProductViewModel()
                            {
                                Id = p.id,
                                Title = p.title,
                                DateCreated = p.dateCreated,
                                Description = p.description,
                                SeoAlias =$"/{Extenstion.ConvertStringToSlug(productName, productId)}"
                            };
                            if (p.images != null)
                            {
                                foreach (var pimg in p.images)
                                {
                                    productImages.Add(new ImageViewModel()
                                    {
                                        Id = pimg.id,
                                        Name = pimg.caption,
                                        Path = pimg.imagePath
                                    });
                                    productImages.Add(pimg);
                                }
                                product.Images = productImages;
                            }
                            products.Add(product);

                        }
                        category.Products = products;
                    }


                    string dataJson = JsonConvert.SerializeObject(category);
                    _ICachingExtension.SetCache(cacheKey, dataJson, 1 * 60);
                    return category;

                }
            }
            catch (Exception ex)
            {

                return category;
            }
        }
    }
}
