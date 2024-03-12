using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class BannerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Path { set; get; } = "";
    }
}
