using Hosted.Contracts.Events;
using Hosted.Outbox;

namespace Hosted.Configs {
    public static class EventBusConfiguration {
        public static IServiceCollection AddInMemoryEventBus(
           this IServiceCollection services) {
            services.AddScoped<IEventBus, InMemoryEventBus>();
            return services;
        }
    }
}
