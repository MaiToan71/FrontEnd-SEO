using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Note { get; set; } = "";
        public string Description { get; set; } = "";
        public string Body { get; set; } = "";
        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>(); 
        public List<ProductViewModel> Products { get; set; } = new List<ProductViewModel>();
    }
}
