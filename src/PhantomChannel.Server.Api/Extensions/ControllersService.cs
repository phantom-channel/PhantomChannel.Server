using System.Text.Json;
using PhantomChannel.Server.Api.Filters;

namespace PhantomChannel.Server.Api.Extensions;
public static class ControllersServiceExtensions
{
    public static IServiceCollection AddControllersService(this IServiceCollection services)
    {

        services.AddControllers(options => { options.Filters.Add<DtoFilter>(); })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                });
        return services;
    }
}