using DigitalCircle.Backend.DigitalCircle.Application.Interfaces;
using DigitalCircle.Backend.DigitalCircle.Application.Services;
using DigitalCircle.Backend.DigitalCircle.Domain.Interfaces;
using DigitalCircle.Backend.DigitalCircle.Infrastructure.Context;
using DigitalCircle.Backend.DigitalCircle.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DigitalCircle.Backend.DigitalCircle.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddDepencyInjection(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=database.db"));


        services.AddScoped<ITB01Repository, TB01Repository>();
        services.AddScoped<ITB01Service, TB01Service>();

        return services;
    }
}
