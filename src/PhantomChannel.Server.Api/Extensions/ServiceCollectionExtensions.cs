using PhantomChannel.Server.Application.Interfaces;
using PhantomChannel.Server.Application.Services;

namespace PhantomChannel.Server.Api.Extensions;

public static class ServiceCollectionExtensions
{

    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

        // 注册用户服务
        services.AddScoped<IUserService, UserService>();
        // 注册邮件服务
        services.AddScoped<IMailerService, MailerService>();
        // 注册JWT服务
        services.AddScoped<IJwtService, JwtService>();
        return services;
    }
}