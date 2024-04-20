using Hosted.Outbox.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hosted.Outbox {
    public static class OutBoxModuleStartup {
        public static IServiceCollection AddoutBoxModule(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<OutboxDbContext>(x => {
                var connectionString = configuration["Modules:OutBoxModule:DbConnectionString"];
                x.UseSqlServer(connectionString);
            });

            return services;
        }
    }
}
