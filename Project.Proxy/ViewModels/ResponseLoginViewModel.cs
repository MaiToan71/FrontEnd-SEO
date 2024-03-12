using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class ResponseLoginViewModel
    {
        public bool Status { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public CustomerViewModel Customer { get; set; } = new CustomerViewModel();
    }
}
