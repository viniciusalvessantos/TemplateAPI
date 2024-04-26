using Hosted.OutBox.WorkerProcess;
using Hosted.Usuarios.Infrastructure.Startup;

namespace Hosted.Configs {
    public static class ServicesExtensions {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddControllers();
            services.AddRouting(x => x.LowercaseUrls = true);

            services.AddUserModule(configuration);

            services.AddApplicationCoreServices();
            services.AddApplicationSwagger();

            services.AddHostedService<OutBoxWorker>();
        }
    }
}
