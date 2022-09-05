using Amirez.AmipBackend.Utils.Mapping;
using Amirez.AmipBackend.Utils.Startup;
using Amirez.AmiPlanner.Utils.Authentication;
using Amirez.AmiPlanner.Utils.Configuration;
using Amirez.Infrastructure.Utils;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Project1
{
    public class Startup
    {
        bool UseSpaStaticFiles = false;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings = services.ConfigureAppsettings(Configuration, "AppSettings");
            services.ConfigureLogger();
            services.ConfigureInvolysSecurity(appSettings.JwtSettings);
            services.ConfigureDatabase("amip2.sqlite");
            services.AddAutoMapper(typeof(AmipMappingProfile));
            services.MapServicesToImplementations();
            services.AddControllersWithViews();
            if (UseSpaStaticFiles)
            {
                // In production, the Angular files will be served from this directory
                services.AddSpaStaticFiles(configuration =>
                {
                    configuration.RootPath = "ClientApp/dist";
                });
            }

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.EnsureDatabaseCreated();

            app.SeedUsers();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            if (UseSpaStaticFiles)
            {
                app.UseStaticFiles();
                if (!env.IsDevelopment())
                {
                    app.UseSpaStaticFiles();
                }
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
            if (UseSpaStaticFiles)
            {
                app.UseSpa(spa =>
                {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
            }
        }
    }
}
