using DotnetSitemapGenerator;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Routing;
using Project.Proxy.Interfaces;
using System.Configuration;

namespace Project.FrontEnd.Sitemaps.Providers
{
    public class ProductSitemapUrlProvider : ISitemapUrlProvider
    {
        //  private readonly Database _db;
        private readonly IMenu _menu;
        private readonly LinkGenerator _linkGenerator;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<ProductSitemapUrlProvider> _logger;
        private IConfiguration _configuration;
        public ProductSitemapUrlProvider(
        IMenu menu,
            LinkGenerator linkGenerator,
            IHttpContextAccessor httpContextAccessor,
            ILogger<ProductSitemapUrlProvider> logger, IConfiguration configuration)
        {
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
            foreach ( var m in menus )
            {
                string domain = $"{_configuration.GetValue<string>("Domain:FrontEnd")}/danh-muc/{m.Slug}";
                var url = domain;

                elements.Add(new SitemapNode(url));
            }
           
            return elements;
        }
    }
}
