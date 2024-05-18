using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace Hosted.Configs {
    public class AddTenantIdHeaderParameter : IOperationFilter {
        public void Apply(OpenApiOperation operation, OperationFilterContext context) {
            if (operation.Parameters == null) {
                operation.Parameters = new List<OpenApiParameter>();
            }

            operation.Parameters.Add(new OpenApiParameter {
                Name = "X-Tenant-ID",
                In = ParameterLocation.Header,
                Description = "Optional Tenant ID",
                Required = false,
                Schema = new OpenApiSchema {
                    Type = "string",
                    Default = new OpenApiString("0") // Valor padrão
                }
            });
        }
    }
}
