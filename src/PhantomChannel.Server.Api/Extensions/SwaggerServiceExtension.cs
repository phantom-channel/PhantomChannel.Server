using System.Reflection;
using Microsoft.OpenApi.Models;

namespace PhantomChannel.Server.Api.Extensions;

public static class SwaggerServiceExtension
{

    public static IServiceCollection AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "PhantomChannel.Server API",
                Description = "An ASP.NET Core Web API for managing PhantomChannel.Server items",
                TermsOfService = new Uri("https://github.com/phantom-channel"),
                Contact = new OpenApiContact
                {
                    Name = "PhantomChannel.Server Contact",
                    Url = new Uri("https://github.com/phantom-channel")
                },
                License = new OpenApiLicense
                {
                    Name = "PhantomChannel.Server License",
                    Url = new Uri("https://github.com/phantom-channel/phantom-chan-server/blob/main/LICENSE")
                }
            });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename), true);
        });
        return services;
    }

}
