using Amirez.AmiPlanner.Common.Configuration;
using Involys.Common.Logger;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amirez.AmiPlanner.Utils.Configuration
{
    public static class ConfigurationExtensions
    {
        public static AppSettings ConfigureAppsettings(this IServiceCollection services, IConfiguration configuration, string appsettingsKey)
        {
            var appSettingsSection = configuration.GetSection(appsettingsKey);
            services.Configure<AppSettings>(appSettingsSection);
            var appSettings = appSettingsSection.Get<AppSettings>();
            return appSettings;
        }
        public static void ConfigureLogger(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManager>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
        }

        public static void AddDefaultCors(this IServiceCollection services, IConfiguration configuration, string defaultCorsKey)
        {
            //Cors Configuration
            services.AddCors(options =>
            {
                options.AddPolicy(defaultCorsKey, policy =>
                {
                    policy.WithOrigins(configuration["AppSettings:ClientUrls"].Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
        }
    }
}
