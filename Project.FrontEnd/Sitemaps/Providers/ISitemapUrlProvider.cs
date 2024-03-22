using DotnetSitemapGenerator;
namespace Project.FrontEnd.Sitemaps.Providers
{
    public interface ISitemapUrlProvider
    {
        Task<IReadOnlyCollection<SitemapNode>> GetNodes();
    }
}
