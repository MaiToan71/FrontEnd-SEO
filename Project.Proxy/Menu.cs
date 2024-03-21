using Newtonsoft.Json;
using Project.Caching;
using Project.Caching.Interfaces;
using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using System.Net.Http.Headers;

namespace Project.Proxy
{
    public class Menu : IMenu
    {
        private readonly string _api;
        private readonly ICachingExtension _ICachingExtension;
        public Menu(string api , ICachingExtension ICachingExtension)
        {
            _ICachingExtension= ICachingExtension;
            _api = api;
        }
        public async Task<List<MenuViewModel>> GetAll()
        {
            List<MenuViewModel> array = new List<MenuViewModel>();
            string cacheKey = $"GetMenus";
            object cache_Payload;
       
            try
            {
                var hitCached = _ICachingExtension.TryGetCache(out cache_Payload, cacheKey);
                if (hitCached)
                {
                    var responseCache = JsonConvert.DeserializeObject<List<MenuViewModel>>((string)cache_Payload);


                    return responseCache;
                }
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                  
                    string url = $"api/publish/categories";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        foreach (var i in response)
                        {
                            int id = i.id;
                            string name = i.name;
                            var newObj = new MenuViewModel
                            {
                                Id= i.id,
                               Name = i.name,
                               ParentId = i.parentId,
                                Description = i.title,
                                Slug= Extenstion.ConvertStringToSlug(name,id)

                            };
                            array.Add(newObj);
                        }
                    }

                    string dataJson = JsonConvert.SerializeObject(array);
                    _ICachingExtension.SetCache(cacheKey, dataJson, 1 * 60);
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
