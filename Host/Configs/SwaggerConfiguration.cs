using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Hosted.Configs {
    public static class SwaggerConfiguration {
        public static void AddApplicationSwagger(this IServiceCollection services) =>
       services.AddSwaggerGen(c => {
           c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme() {
               Name = "Bearer",
               BearerFormat = "JWT",
               Scheme = "bearer",
               Description = "Specify the authorization token.",
               In = ParameterLocation.Header,
               Type = SecuritySchemeType.Http,
           });
           // Adiciona o cabeçalho X-Tenant-ID às definições globais do Swagger
           c.AddSecurityDefinition("TenantId", new OpenApiSecurityScheme {
               In = ParameterLocation.Header,
               Name = "X-Tenant-ID",
               Type = SecuritySchemeType.ApiKey,
               Description = "Optional Tenant ID"
           });

           // Define um valor padrão para o cabeçalho X - Tenant - ID
           c.OperationFilter<AddTenantIdHeaderParameter>();
           c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                }
           });

           //c.SwaggerDoc("v1.0", new OpenApiInfo { Title = "My Demo API", Version = "1.0" });
           c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

       });

    }
}
