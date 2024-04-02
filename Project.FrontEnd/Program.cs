
using HealthChecks.UI.Client;
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
using System.Threading.RateLimiting;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNetCore7;
using WebMarkupMin.Core;

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
            builder.Services.AddSingleton<IMenu>(l => new Menu(api, new CachingExtension(new Caching.Caching())));
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
            builder.Services.AddOutputCache(options =>
            {
                options.AddPolicy("sitemap", b => b.Expire(TimeSpan.FromSeconds(1)));
            });


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
         "image/svg+xml"
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

            builder.Services.AddResponseCaching();

            builder.Services.AddRateLimiter(options =>
            {
                options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
                    RateLimitPartition.GetFixedWindowLimiter(
                        partitionKey: httpContext.GetRemoteIPAddress().ToString(),
                        factory: partition => new FixedWindowRateLimiterOptions
                        {
                            AutoReplenishment = true,
                            PermitLimit = 10,
                            QueueLimit = 0,
                            Window = TimeSpan.FromMinutes(1)
                        }));
                options.RejectionStatusCode = 429;

                options.OnRejected = async (context, token) =>
                {
                    context.HttpContext.Response.StatusCode = 429;
                    if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                    {
                        await context.HttpContext.Response.WriteAsync(
                            "https://hanoionline.vn too busy", cancellationToken: token);
                        //context.HttpContext.Response.Redirect("/Error");
                    }
                    else
                    {
                        await context.HttpContext.Response.WriteAsync(
                            "https://hanoionline.vn too busy", cancellationToken: token);
                        //context.HttpContext.Response.Redirect("/Error");
                    }
                };

            });

            // Add services to the container.
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllersWithViews(options =>
            {
                options.CacheProfiles.Add("Default30", new Microsoft.AspNetCore.Mvc.CacheProfile
                {
                    Duration = 30,
                    VaryByHeader = "User-Agent",
                    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client

                });

                options.CacheProfiles.Add("Default60", new Microsoft.AspNetCore.Mvc.CacheProfile
                {
                    Duration = 60,
                    VaryByHeader = "User-Agent",
                    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client

                });

                options.CacheProfiles.Add("Default300", new Microsoft.AspNetCore.Mvc.CacheProfile
                {
                    Duration = 300,
                    VaryByHeader = "User-Agent",
                    Location = Microsoft.AspNetCore.Mvc.ResponseCacheLocation.Client

                });
            });

            builder.Services.AddHealthChecks()
                        .AddUrlGroup(new Uri(api), name: "konsureindo.net", failureStatus: Microsoft.Extensions.Diagnostics.HealthChecks.HealthStatus.Degraded);



            builder.Services.AddWebOptimizer(pipeline =>
            {
                // pipeline.AddCssBundle("/css/video-bundle.css", "/css/video-js.min.css", "/css/videojs-style.min.css", "/css/videojs-quality-menu.css", "/css/player.css");
                // pipeline.AddJavaScriptBundle("/js/bundle.js", "/js/site.js", "/lib/bootstrap/js/bootstrap.js");
                pipeline.MinifyCssFiles();
                pipeline.MinifyJsFiles();
            });

            builder.Services.AddWebMarkupMin(options =>
            {
                options.AllowMinificationInDevelopmentEnvironment = true;
                options.AllowCompressionInDevelopmentEnvironment = true;
            })
                .AddHtmlMinification(options =>
                {
                    HtmlMinificationSettings settings = options.MinificationSettings;
                    settings.RemoveRedundantAttributes = true;
                    settings.RemoveHttpProtocolFromAttributes = true;
                    //settings.RemoveHttpsProtocolFromAttributes = true;
                })
                .AddHttpCompression(options =>
                {
                    options.CompressorFactories = new List<ICompressorFactory>
                    {
            new BuiltInBrotliCompressorFactory(new BuiltInBrotliCompressionSettings
            {
                Level = CompressionLevel.Fastest
            }),
            new DeflateCompressorFactory(new DeflateCompressionSettings
            {
                Level = CompressionLevel.Fastest
            }),
            new GZipCompressorFactory(new GZipCompressionSettings
            {
                Level = CompressionLevel.Fastest
            })
                    };
                })
                ;


        


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

            app.UseResponseCompression();
            app.UseResponseCaching();
            const string cacheMaxAge = "86400";
            app.UseStaticFiles(new StaticFileOptions()
            {
                OnPrepareResponse = ctx =>
                {
                    ctx.Context.Response.Headers.TryAdd("Cache-Control", $"public, max-age={cacheMaxAge}");
                    if (ctx.File.Name.EndsWith(".js.gz"))
                    {
                        ctx.Context.Response.Headers["Content-Type"] = "text/javascript";
                        ctx.Context.Response.Headers["Content-Encoding"] = "gzip";
                    }
                    if (ctx.File.Name.EndsWith(".css.gz"))
                    {
                        ctx.Context.Response.Headers["Content-Type"] = "text/css";
                        ctx.Context.Response.Headers["Content-Encoding"] = "gzip";
                    }
                },
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseSession();

            app.UseWebOptimizer();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            });

            app.UseWebMarkupMin();

            app.UseHealthChecks("/xhealth", new Microsoft.AspNetCore.Diagnostics.HealthChecks.HealthCheckOptions
            {
                Predicate = _ => true,
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            });


            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
