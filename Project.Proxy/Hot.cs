﻿using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy
{
    public class Hot : IHot
    {
        private readonly string _api;
        public Hot(string api)
        {
            _api = api;
        }

        public async Task<List<CategoryOutstandViewModel>> GetCategoryHot()
        {
            List<CategoryOutstandViewModel> array = new List<CategoryOutstandViewModel>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/categories/outstand";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        foreach (var i in response)
                        {
                            List<ProductViewModel> products = new List<ProductViewModel>();
                            string catName = i.name;
                            int cateId = i.id;
                            var newObj = new CategoryOutstandViewModel
                            {
                                Id = i.id,
                                Name = i.name,
                                Description = i.description,
                                Slug = $"{Extenstion.ConvertStringToSlug(catName, cateId)}",

                            };
                            if (i.products != null)
                            {
                                foreach (var p in i.products)
                                {
                                    int productId = p.id;
                                    string productName = p.title;
                                    var product = new ProductViewModel()
                                    {
                                        Id = p.id,
                                        Title = p.title,
                                        SeoAlias = $"/{Extenstion.ConvertStringToSlug(productName, productId)}",
                                    };
                                    products.Add(product);
                                }
                            }
                            newObj.Products = products;
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

        public async Task<List<ProductViewModel>> GetHot()
        {
            List<ProductViewModel> array = new List<ProductViewModel>();
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    string url = $"api/publish/home/hot";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        foreach (var i in response)
                        {
                            List<ImageViewModel> Images = new List<ImageViewModel>();
                            int productId = i.id;
                            string productName = i.title;
                            var newObj = new ProductViewModel
                            {
                                Id = i.id,
                                Body = i.body,
                                Title = i.title,
                                ViewCount= i.viewCount,
                                SeoAlias = $"/{Extenstion.ConvertStringToSlug(productName, productId)}",
                                Description = i.description
                            };
                            
                            foreach(var img in i.images)
                            {
                                var image = new ImageViewModel()
                                {
                                    Id = img.id,
                                    Name = img.caption,
                                    Path = $"{_api}{img.imagePath}"
                                };
                                Images.Add(image);
                            }
                            newObj.Images = Images;
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
