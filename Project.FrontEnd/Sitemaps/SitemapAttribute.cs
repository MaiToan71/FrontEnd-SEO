using DotnetSitemapGenerator;
using DotnetSitemapGenerator.Images;
using DotnetSitemapGenerator.News;

namespace Project.FrontEnd.Sitemaps
{
    public class SitemapAttribute
    {
        public RouteValueDictionary? RouteValues { get; set; }
        public DateTime? LastModificationDate { get; set; }
        public ChangeFrequency? ChangeFrequency { get; set; }
        public decimal? Priority { get; set; }
    }
}
