using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Proxy.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Body { get; set; } = "";
        public string SeoAlias { get; set; } = "";
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int ViewCount { set; get; }
        public string DateCreated { get; set; } = "";
        public List<ImageViewModel> Images { get; set; } = new List<ImageViewModel>();
    }
}
