using Hosted.Usuarios.Application.Commands.Register;
using Hosted.Usuarios.Application.Queries.GetUsuariosDetalhes;
using Hosted.Usuarios.Contract;
using Hosted.Usuarios.Domain.Entities;
using Hosted.Usuarios.Domain.Interfaces;
using Hosted.Usuarios.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Refit;
using System.Text;


namespace Hosted.Usuarios.Infrastructure.Startup {
    public static class UsuariosModuleStartup {
        public static IServiceCollection AddUserModule(
            this IServiceCollection services, IConfiguration configuration) {

            services.AddMediatR(cfg => {
                cfg.RegisterServicesFromAssembly(typeof(RegisterUsuariosCommand).Assembly); // Adiciona os handlers localizados no mesmo assembly que a classe Startup
            });
            services.AddDbContext<UsuariosDbContext>(x => {
                var connectionString = configuration["Modules:UsersModule:DbConnectionString"];
                x.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.EnableRetryOnFailure());
            });
            services.AddIdentityCore<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<UsuariosDbContext>();

            services
                .AddRefitClient<IUsuariosAPI>()
                .ConfigureHttpClient(c => {
                    var userModuleUrl = configuration["Modules:UsersModule:Url"];
                    c.BaseAddress = new Uri(userModuleUrl!);
                });

            services.AddScoped<IUsuariosService, GetUsuariosDetalhesQueryHandler>();

            services.Configure<IdentityOptions>(options => {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // AppUser settings.
                options.User.AllowedUserNameCharacters =
                    "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt => {
                var key = Encoding.ASCII.GetBytes(configuration["Jwt:Secret"]!);
                var issuer = configuration["Jwt:Issuer"];
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = new TokenValidationParameters {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = issuer,
                    ValidAudiences = new List<string>() { issuer! },
                    ValidateAudience = true,
                    RequireExpirationTime = false,
                    ValidateLifetime = true
                };
            });


            services.AddScoped<IJwtService, JwtService>();

            return services;
        }

    }
}
