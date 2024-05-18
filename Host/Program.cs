using Hosted.Configs;
using Hosted.Infrastructure.Exceptions;
using Hosted.Outbox;
using Hosted.OutBox.WorkerProcess;
using Hosted.Usuarios.Infrastructure.Startup;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers().AddJsonOptions(options => {
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});

builder.Services.AddRouting(x => x.LowercaseUrls = true);

builder.Services.AddoutBoxModule(builder.Configuration).AddUserModule(builder.Configuration);
builder.Services.AddApplicationCoreServices();
builder.Services.AddApplicationSwagger();

builder.Services.AddHostedService<OutBoxWorker>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.


if (app.Environment.IsDevelopment()) {
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();

app.UseSwagger();

// Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
// specifying the Swagger JSON endpoint.
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Modular Monolith API");
    //c.RoutePrefix = string.Empty;
});

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseMiddleware<TenantMiddleware>();
app.UseMiddleware<ExceptionLoggingMiddleware>();

app.UseEndpoints(endpoints => {
    _ = endpoints.MapControllers();
});

app.Run();
