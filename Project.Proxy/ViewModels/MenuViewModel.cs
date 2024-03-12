using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class MenuViewModel
    {
        public int Id { get; set; }
        public string Slug { get; set; } = "";
        public int ParentId { get; set; } = 0;
        public string Name { set; get; } = "";
        public string Description { set; get; } = "";
    }
}
