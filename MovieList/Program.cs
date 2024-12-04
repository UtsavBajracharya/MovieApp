using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using MovieList.Models;

namespace MovieList
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureServices((context, services) =>
                    {
                        // Add services to the container
                        var configuration = context.Configuration;

                        // Add the MovieContext to the DI container
                        services.AddDbContext<MovieContext>(options =>
                            options.UseSqlServer(configuration.GetConnectionString("MovieContext")));

                        // Add identity services and configure the default sign-in and role management
                        services.AddDefaultIdentity<IdentityUser>(options =>
                        {
                            options.SignIn.RequireConfirmedAccount = true;  // You can customize this
                        })
                        .AddRoles<IdentityRole>()
                        .AddEntityFrameworkStores<MovieContext>();

                        // Add controllers and views for the MVC pipeline
                        services.AddControllersWithViews();

                        // Configure routing (Lowercase URLs and append trailing slash)
                        services.AddRouting(options =>
                        {
                            options.LowercaseUrls = true;
                            options.AppendTrailingSlash = true;
                        });

                    });

                    webBuilder.Configure((context, app) =>
                    {
                        var env = context.HostingEnvironment;

                        // Development-specific error page
                        if (env.IsDevelopment())
                        {
                            app.UseDeveloperExceptionPage();
                        }
                        else
                        {
                            app.UseExceptionHandler("/Home/Error");
                            app.UseHsts();  // Use HTTP Strict Transport Security in production
                        }

                        app.UseHttpsRedirection();
                        app.UseStaticFiles();  // Enable static file serving (e.g., images, CSS, JS)

                        app.UseRouting();  // Enable routing in the app
                        app.UseAuthentication();  // Enable authentication middleware
                        app.UseAuthorization();   // Enable authorization middleware

                        // Configure MVC endpoints
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapControllerRoute(
                                name: "default",
                                pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");  // Default route
                            endpoints.MapRazorPages();  // For Razor Pages if used
                        });
                    });
                });
    }
}