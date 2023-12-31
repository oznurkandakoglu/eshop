using eshop.Application.Services;
using eshop.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace eshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<IProductService, FakeProductService>();
            builder.Services.AddScoped<ICategoryService, FakeCategoryService>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddSession();

            var connectionStrings = builder.Configuration.GetConnectionString("db");
            builder.Services.AddDbContext<AkbankDbContext>(option => option.UseSqlServer(connectionStrings));

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                            .AddCookie(option =>
                            {
                                option.LoginPath = "/Users/Login";
                                option.ReturnUrlParameter = "gidilecekSayfa";
                                option.AccessDeniedPath = "/Users/AccessDenied";
                            });
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
            app.UseSession();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}