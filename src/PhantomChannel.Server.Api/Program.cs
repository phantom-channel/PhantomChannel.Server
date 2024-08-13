using PhantomChannel.Server.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();

builder.Logging.AddConsole();

builder.Logging.AddDebug();

builder.Logging.AddEventSourceLogger();

builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddApplicationServices(builder.Configuration);

builder.Services.AddSwaggerServices(builder.Configuration);

builder.Services.AddCorsServices(builder.Configuration);

builder.Services.AddJwtServices(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddControllersService();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseGlobalExceptionHandler();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("AllowedHosts");

app.MapControllers();

app.Run();