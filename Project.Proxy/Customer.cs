using Project.Proxy.Interfaces;
using Project.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Project.Proxy
{
    public class Customer : ICustomer
    {
        private readonly string _api;
        public Customer(string api)
        {
            _api = api;
        }

        public async Task<CustomerViewModel> GetById(int id)
        {
            var customer = new CustomerViewModel();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = $"api/auths/customers/{id}";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        List<ImageViewModel> images = new List<ImageViewModel>();
                        foreach (var i in response.images)
                        {
                            var newImage = new ImageViewModel()
                            {
                                Id = i.id,
                                Name = i.caption,
                                Path = $"{_api}{i.imagePath}"
                            };
                            images.Add(newImage);
                        }
                        customer.Id = (int)response.id;
                        customer.FullName = response.fullName;
                        customer.PhoneNumber = response.phoneNumber;
                        customer.Address = response.address;
                        customer.City = response.city;
                        customer.DateOfBirth = response.dateOfBirth;
                        customer.DateOfCmnd = response.dateOfCmnd;
                        customer.Money = response.money;
                        customer.MoneyTotal = response.moneyTotal;
                        customer.IsMoney=response.isMoney;
                        customer.City = response.city;
                        customer.Region= response.region;
                        customer.Images=images;
                        customer.Cmnd = response.cmnd;
                        customer.WorkflowState = response.workflowState;
                    }

                    return customer;

                }
            }
            catch (Exception ex)
            {

                return customer;
            }
        }

        public async Task<List<CustomerCalendarViewModel>> GetCustomerInCalenar(string cmnd)
        {
            List<CustomerCalendarViewModel> data = new List<CustomerCalendarViewModel>();


            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string url = $"/api/CustomerDates/searching?cmnd={cmnd}&PageIndex=1&PageSize=100";
                    var responseMessage = await httpClient.GetAsync(url);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        foreach (var item in response.items)
                        {
                            var c = new CustomerCalendarViewModel()
                            {
                                HoVaTen = item.hoVaTen,
                                GioiTinh = item.gioiTinh,
                                NgayThangNamSinh = item.ngayThangNamSinh,
                                SoCMND = item.soCMND,
                                NoiCuTru = item.noiCuTru,
                                GiayChungNhanSucKhoe = item.giayChungNhanSucKhoe,
                                DaCoGiayPhepLaiXeHang = item.daCoGiayPhepLaiXeHang,
                                DaCoGiayPhepLaiXeSo = item.daCoGiayPhepLaiXeSo,
                                DaCoGiayPhepLaiXeNgayTrung = item.daCoGiayPhepLaiXeNgayTrung,
                                PhanKhaiSoKmLaiXeAnToan = item.phanKhaiSoKmLaiXeAnToan,
                                SoChungChiNgheHoacGiay = item.soChungChiNgheHoacGiay,
                                LopKhoa = item.lopKhoa,
                                HangDuSatHach = item.hangDuSatHach,
                                GhiChu = item.ghiChu,
                                NgayThi = item.ngayThi,
                            };
                            data.Add(c);
                        }
                     
                    }

                    return data;

                }
            }
            catch (Exception ex)
            {

                return data;
            }
        }
        public async Task<ResponseLoginViewModel> Login(LoginViewModel request)
        {
            var customer = new ResponseLoginViewModel();

            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    httpClient.BaseAddress = new Uri(_api);
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");
                    string url = $"api/auths/customers/login";
                    var responseMessage = await httpClient.PostAsync(url, content);
                    if (responseMessage.IsSuccessStatusCode)
                    {
                        var response = await responseMessage.Content.ReadAsAsync<dynamic>();
                        customer.Status = response.status;
                        customer.Message = response.message;
                        customer.Customer = new CustomerViewModel()
                        {
                            Id = (int)response.customer.id,
                            FullName = response.customer.fullName
                        };

                    }

                    return customer;

                }
            }
            catch (Exception ex)
            {

                return customer;
            }
        }
    }
}
