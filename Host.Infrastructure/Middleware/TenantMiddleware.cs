using Microsoft.AspNetCore.Http;

namespace Hosted.Infrastructure.Middleware {
    public class TenantMiddleware {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context) {
            if (context.Request.Headers.TryGetValue("X-Tenant-ID", out var tenantId)) {
                context.Items["TenantId"] = tenantId.ToString();

            }


            //else {
            //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //    await context.Response.WriteAsync("Tenant ID is missing in the headers.");
            //    return;
            //}

            await _next(context);
        }
    }
}
