using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using System.Net.Http.Headers;

namespace Project.Proxy
{
    public class Menu : IMenu
    {
        private readonly string _api;
       
        public Menu(string api )
        {
            _api = api;
        }
        public async Task<List<MenuViewModel>> GetAll()
        {
            List<MenuViewModel> array = new List<MenuViewModel>();
            try
            {
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
