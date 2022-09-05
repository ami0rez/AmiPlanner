using Amirez.AmiPlanner.Common.Configuration;
using Amirez.AmiPlanner.Common.Constants;
using Amirez.AmiPlanner.Utils.Authentication.JwtFeatures;
using Amirez.AmiPlanner.Utils.Authentication.RefreshToken;
using Amirez.Infrastructure.Data;
using Amirez.Infrastructure.Data.Model.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Linq;
using System.Text;

namespace Amirez.AmiPlanner.Utils.Authentication
{

    /// <summary>
    /// Extension Methods For security
    /// </summary>
    public static class SecurityExtensions
    {
        /// <summary>
        /// Help seed database with users, used for development mode
        /// </summary>
        /// <param name="app"></param>
        public static void SeedUsers(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<UtilisateurDataModel>>();
                var user = new UtilisateurDataModel
                {
                    Nom = "Involys",
                    Prenom = "Administrateur",
                    RoleId = context.Roles.FirstOrDefault(r => r.RoleType == Roles.Administrateur).Id,
                    Bloque = false,
                    Email = "administrateur@involys.com",
                    NormalizedEmail = "ADMINISTRATEUR@INVOLYS.COM",
                    UserName = "Administrateur",
                    NormalizedUserName = "ADMINISTRATEUR",
                    PhoneNumber = "+111111111111",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                    SecurityStamp = Guid.NewGuid().ToString("D")
                };


                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var password = new PasswordHasher<UtilisateurDataModel>();
                    var hashed = password.HashPassword(user, "Password@1234");
                    user.PasswordHash = hashed;
                    var result = userManager.CreateAsync(user).Result;

                }
                context.SaveChangesAsync();


            }
        }


        /// <summary>
        /// Configure security, to be called from configureServices in startup
        /// </summary>
        /// <param name="services"></param>
        /// <param name="jwtSettings"></param>
        public static void ConfigureInvolysSecurity(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.ValidIssuer,
                    ValidAudience = jwtSettings.ValidAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(jwtSettings.SecurityKey))
                };
            });
            services.AddScoped<JwtHandler>();

            services.Configure<RefreshTokenOptions>(option =>
            {
                option.TokenLifespan = TimeSpan.FromMinutes(jwtSettings.RefreshTokenLifeSpan);
            });
            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 0;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;


                // User settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
                options.User.RequireUniqueEmail = false;
            });

            services.AddIdentity<UtilisateurDataModel, IdentityRole<Guid>>(cfg => {
                cfg.User.RequireUniqueEmail = false;
            })
                .AddTokenProvider<RefreshTokenProvider<UtilisateurDataModel>>(Constants.RefreshTokenProvider)
                .AddTokenProvider<DataProtectorTokenProvider<UtilisateurDataModel>>(TokenOptions.DefaultProvider)
                .AddEntityFrameworkStores<DatabaseContext>();
        }
    }
}
