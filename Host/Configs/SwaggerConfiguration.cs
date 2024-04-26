﻿using Microsoft.OpenApi.Models;

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
           //c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);

       });

    }
}
