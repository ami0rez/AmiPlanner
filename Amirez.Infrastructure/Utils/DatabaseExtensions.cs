using Amirez.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Amirez.Infrastructure.Utils
{
    public static class DatabaseExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, string databaseName)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = System.IO.Path.Join(path, databaseName);


            services.AddDbContext<DatabaseContext>(options =>
               options.UseSqlite($"Data Source={dbPath}")
               .UseSnakeCaseNamingConvention()
               );
        }
        public static void EnsureDatabaseCreated(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>();
                context.Database.EnsureCreated();
            }
        }
    }
}
