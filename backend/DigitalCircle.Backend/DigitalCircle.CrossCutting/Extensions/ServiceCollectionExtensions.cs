using Microsoft.OpenApi.Models;

namespace DigitalCircle.Backend.DigitalCircle.CrossCutting.Extensions;

public static class ServiceCollectionExtensions
{
    public static WebApplicationBuilder AddApiSwagger(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwagger();
        return builder;
    }

    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "DigitalCircleCRUD", Version = "v1" });
     
        });
        return services;
    }
}
