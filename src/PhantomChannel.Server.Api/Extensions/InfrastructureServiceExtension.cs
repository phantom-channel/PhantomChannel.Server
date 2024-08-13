using Microsoft.EntityFrameworkCore;
using PhantomChannel.Server.Infrastructure.Data;
using PhantomChannel.Server.Infrastructure.Redis;

namespace PhantomChannel.Server.Api.Extensions;

public static class InfrastructureServiceExtension
{

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<PhantomDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
        });

        return services;
    }

}
