using System.Net;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PhantomChannel.Server.Api.Models;
using PhantomChannel.Server.Domain.Enums;

namespace PhantomChannel.Server.Api.Extensions;

public static class JwtServiceExtension
{

    public static IServiceCollection AddJwtServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };

                options.Events = new JwtBearerEvents
                {

                    OnAuthenticationFailed = context =>
                    {

                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;

                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            var expiredResponse = JsonSerializer.Serialize(new ApiResponse { Code = HttpStatusCode.Unauthorized, Msg = "TOKEN 过期" });
                            return context.Response.WriteAsync(expiredResponse);
                        }

                        var result = JsonSerializer.Serialize(new ApiResponse { Code = HttpStatusCode.Unauthorized, Msg = "TOKEN 无效" });
                        return context.Response.WriteAsync(result);
                    },
                    OnChallenge = context =>
                    {


                        if (context.Response.HasStarted)
                        {
                            context.HandleResponse();
                            return Task.CompletedTask;
                        }


                        context.Response.Clear();
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 401;
                        context.HandleResponse();

                        var result = JsonSerializer.Serialize(new ApiResponse { Code = HttpStatusCode.Unauthorized, Msg = "TOKEN 缺失" });
                        return context.Response.WriteAsync(result);

                    },
                    OnTokenValidated = context =>
                    {
                        return Task.CompletedTask;
                    },
                    OnForbidden = context =>
                    {
                        context.Response.ContentType = "application/json";
                        context.Response.StatusCode = 403;
                        var result = JsonSerializer.Serialize(new ApiResponse { Code = HttpStatusCode.Forbidden, Msg = "权限不足" });
                        return context.Response.WriteAsync(result);
                    }
                };
            });

        foreach (var role in Enum.GetValues<RoleEnum>())
        {
            services.AddAuthorizationBuilder()
                .AddPolicy(role.ToString(), policy => policy.RequireRole(role.ToString()));
        }
        return services;
    }

}
