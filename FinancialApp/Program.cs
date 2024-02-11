using FinancialAppInfrastructure.Data.ApplicationContext;
using Highsoft.Web.Mvc.Charts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinancialApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<MyContextApp>(options => options.UseSqlServer(
                builder.Configuration.GetConnectionString("MyConnection")));
            builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<MyContextApp>();

            builder.Services.AddScoped<IdentityUser>();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Login";
                //options.AccessDeniedPath = "/Home/AccessDenied";
            });


            // Add services to the container.
            builder.Services.AddControllersWithViews();

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

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            app.Run();
        }
    }
}