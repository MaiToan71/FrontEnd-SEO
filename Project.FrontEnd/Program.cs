
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Project.Caching;
using Project.Caching.Interfaces;
using Project.FrontEnd.Sitemaps;
using Project.Proxy;
using Project.Proxy.Interfaces;
using Serilog;
using System.IO.Compression;

namespace Project.FrontEnd
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
            Microsoft.Extensions.Configuration.ConfigurationManager configuration = builder.Configuration; // allows both to access and to set up the config
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            string api = configuration["Domain:API"];
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession();

            builder.Host.UseSerilog((hostingContext, loggerConfig) =>
            loggerConfig.ReadFrom.Configuration(hostingContext.Configuration));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Proxy
            builder.Services.AddSingleton<IMenu>(l => new Menu(api,new CachingExtension(new Caching.Caching())));
            builder.Services.AddSingleton<IBanner>(l => new Banner(api, new CachingExtension(new Caching.Caching())));
            builder.Services.AddSingleton<IHot>(l => new Hot(api, new CachingExtension(new Caching.Caching())));
            builder.Services.AddSingleton<ICategory>(l => new Category(api, new CachingExtension(new Caching.Caching())));
            builder.Services.AddSingleton<IDetail>(l => new Detail(api, new CachingExtension(new Caching.Caching())));
            builder.Services.AddSingleton<ICustomer>(l => new Customer(api));
            builder.Services.AddSingleton<IProduct>(l => new Product(api, new CachingExtension(new Caching.Caching())));

            builder.Services.AddResponseCompression(options =>
            {
                IEnumerable<string> MimeTypes = new[]
                 {
                     // General
                     "text/plain",
                     "text/html",
                     "text/css",
                     "font/woff2",
                     "application/javascript",
                     "image/x-icon",
                     "image/png",
                     "image/svg+xml",
                     "text/javascript"
                 };

                options.EnableForHttps = true;
                options.MimeTypes = MimeTypes;
                options.Providers.Add<BrotliCompressionProvider>();
                options.Providers.Add<GzipCompressionProvider>();
            });
            builder.Services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            builder.Services.Configure<GzipCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.SmallestSize;
            });

            // my unique extension method for sitemap information
            builder.Services.AddSitemap();
            builder.Services.AddOutputCache(options => {
                options.AddPolicy("sitemap", b => b.Expire(TimeSpan.FromSeconds(1)));
            });



            var app = builder.Build();
          //  app.UseXMLSitemap();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
               // app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                 ForwardedHeaders.XForwardedProto
            });

            app.MapSitemap().CacheOutput("sitemap");

           

          //  app.UseStatusCodePagesWithRedirects("/Home/Error");

            const string cacheMaxAge = "86400";
            app.UseStaticFiles(
                new StaticFileOptions()
                {
                    OnPrepareResponse = ctx =>
                    {
                        ctx.Context.Response.Headers.TryAdd("Cache-Control", $"public, max-age={cacheMaxAge}");
                    }
                });

            app.UseResponseCompression();
            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
