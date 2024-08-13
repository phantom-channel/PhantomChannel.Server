using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using PhantomChannel.Server.Api.Models;

namespace PhantomChannel.Server.Api.Extensions;

public static class ExceptionHandlerExtensions
{
    public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(builder =>
        {
            builder.Run(async context =>
            {
                context.Response.ContentType = "application/json";
                var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (exceptionFeature != null)
                {
                    var error = new ApiResponse
                    {
                        Code = (HttpStatusCode)context.Response.StatusCode | HttpStatusCode.InternalServerError,
                        Msg = exceptionFeature.Error.Message
                    };
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                    };
                    var errObj = JsonSerializer.Serialize(error, options);

                    await context.Response.WriteAsync(errObj).ConfigureAwait(false);
                }
            });
        });
        return app;
    }
}