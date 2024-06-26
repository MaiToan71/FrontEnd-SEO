﻿
using Project.Proxy.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.Interfaces
{
    public interface ICustomer
    {
       Task<ResponseLoginViewModel> Login(LoginViewModel request);
        Task<bool> Register(RegisterViewModel request);
        Task<CustomerViewModel> GetById(int id);
        Task<List<CustomerCalendarViewModel>> GetCustomerInCalenar(string cmnd, string searchDate);
    }
}
