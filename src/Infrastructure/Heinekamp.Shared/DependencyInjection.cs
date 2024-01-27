using Heinekamp.Application.Services;
using Heinekamp.Shared.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Heinekamp.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedServices(this IServiceCollection services)
    {
        services.AddScoped<IFileStorageService, FileStorageService>();

        return services;
    }
}