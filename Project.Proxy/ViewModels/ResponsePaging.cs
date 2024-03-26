using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class ResponsePaging
    {
        public int Total { get; set; } = 0;
        public List<ProductViewModel> Data { get; set; } = new List<ProductViewModel>();
    }
}
