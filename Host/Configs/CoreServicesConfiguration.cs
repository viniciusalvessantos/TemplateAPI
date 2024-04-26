using Hosted.Infrastructure.Behaviours;
using Hosted.Infrastructure.UsuarioContext;
using MediatR;

namespace Hosted.Configs {
    public static class CoreServicesConfiguration {
        public static void AddApplicationCoreServices(this IServiceCollection services) {
            //  services.AddMediatR(typeof(ProductCratedIntegrationEvent));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            //services.AddValidatorsFromAssemblyContaining<AddProductValidator>();

            services.AddInMemoryEventBus();
            services.AddHttpContextAccessor();

            services.AddScoped<IUsuarioContext, UsuarioContext>();

        }
    }
}
