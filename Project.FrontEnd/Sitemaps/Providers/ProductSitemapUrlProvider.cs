using DotnetSitemapGenerator;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Routing;
using Project.Proxy;
using Project.Proxy.Interfaces;
using System.Configuration;

namespace Project.FrontEnd.Sitemaps.Providers
{
    public class ProductSitemapUrlProvider : ISitemapUrlProvider
    {
        //  private readonly Database _db;
        private readonly IMenu _menu;
        private readonly IProduct _product;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ProductSitemapUrlProvider> _logger;
        private IConfiguration _configuration;
        public ProductSitemapUrlProvider(
            IProduct product,
        IMenu menu,
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<ProductSitemapUrlProvider> logger, IConfiguration configuration)
        {
            _product = product;
            _configuration = configuration;
            _menu = menu;
            _linkGenerator = linkGenerator;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public async Task<IReadOnlyCollection<SitemapNode>> GetNodes()
        {
            var elements = new List<SitemapNode>();
            var menus = await _menu.GetAll();
            string domainHome = $"{_configuration.GetValue<string>("Domain:FrontEnd")}";

            elements.Add(new SitemapNode(domainHome)
            {
                Priority = 1,
                LastModificationDate = DateTime.Now,
            });

            elements.Add(new SitemapNode($"{_configuration.GetValue<string>("Domain:FrontEnd")}/tra-cuu-ho-so")
            {
                Priority = 1,
                LastModificationDate = DateTime.Now,
            });

            foreach (var m in menus)
            {
                string domain = $"{_configuration.GetValue<string>("Domain:FrontEnd")}/danh-muc/{m.Slug}";
                var url = domain;

                elements.Add(new SitemapNode(url)
                {
                    Priority = 1,
                    LastModificationDate = DateTime.Now,
                });
            }

            var products = await _product.GetAllPagingProduct(1, 30,0);
            foreach (var p in products.Data)
            {
                string domain = $"{_configuration.GetValue<string>("Domain:FrontEnd")}{p.SeoAlias}";
                var url = domain;

                elements.Add(new SitemapNode(url)
                {
                    Priority = 1,
                    LastModificationDate = p.DateUpdated,
                });
            }
            return elements;
        }
    }
}
