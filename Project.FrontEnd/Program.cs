using Microsoft.Extensions.DependencyInjection.Extensions;
using Project.Proxy;
using Project.Proxy.Interfaces;

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

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //Proxy
            builder.Services.AddSingleton<IMenu>(l => new Menu(api));
            builder.Services.AddSingleton<IBanner>(l => new Banner(api));
            builder.Services.AddSingleton<IHot>(l => new Hot(api));
            builder.Services.AddSingleton<ICategory>(l => new Category(api));
            builder.Services.AddSingleton<IDetail>(l => new Detail(api));
            builder.Services.AddSingleton<ICustomer>(l => new Customer(api));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

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
