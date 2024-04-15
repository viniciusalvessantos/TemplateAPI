using Hosted.Outbox.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace Hosted.Outbox {
    public static class OutBoxModuleStartup {
        public static IServiceCollection AddoutBoxModule(this IServiceCollection services) {
            services.AddDbContext<OutboxDbContext>();
            return services;
        }
    }
}
