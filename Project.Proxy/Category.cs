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
    public class Category : ICategory
    {
        private readonly string _api;
        public Category(string api)
        {
            _api = api;
        }
        public async Task<CategoryViewModel> GetCategory(int id)
        {
            var category = new CategoryViewModel();
            try
            {
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
