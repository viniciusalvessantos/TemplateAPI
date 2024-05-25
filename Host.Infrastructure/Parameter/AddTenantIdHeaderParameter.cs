
using Hosted.Domain.Attributes;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hosted.Configs {
    public class AddTenantIdHeaderParameter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if (operation.Parameters == null) {
                operation.Parameters = new List<OpenApiParameter>();
            }

            // Verificar se o atributo está presente no método
            var requireTenantIdAttribute = context.MethodInfo
                .GetCustomAttributes(true)
                .OfType<RequireTenantIdAttribute>()
                .FirstOrDefault();

            // Se não estiver no método, verificar no controlador
            if (requireTenantIdAttribute == null) {
                requireTenantIdAttribute = context.MethodInfo.DeclaringType!
                    .GetCustomAttributes(true)
                    .OfType<RequireTenantIdAttribute>()
                    .FirstOrDefault();
            }

            var isRequired = requireTenantIdAttribute?.IsRequired ?? false;
            if (isRequired) {
                operation.Parameters.Add(new OpenApiParameter {
                    Name = "X-Tenant-ID",
                    In = ParameterLocation.Header,
                    Description = isRequired ? "Required Tenant ID" : "Optional Tenant ID",
                    Required = isRequired,
                    Schema = new OpenApiSchema {
                        Type = "string",
                        Default = new OpenApiString(isRequired ? string.Empty : "0") // Valor padrão
                    }
                });
            }

        }
    }
}
