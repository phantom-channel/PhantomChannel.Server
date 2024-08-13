namespace PhantomChannel.Server.Api.Extensions;

public static class CorsServiceExtension
{

    public static IServiceCollection AddCorsServices(this IServiceCollection services, IConfiguration configuration)
    {
        var allowedHosts = configuration["AllowedHosts"]!.Split(",");
        services.AddCors(options =>
        {
            options.AddPolicy("AllowSpecificOrigins",
                builder =>
                {
                    builder.WithOrigins(allowedHosts)
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        return services;
    }

}
