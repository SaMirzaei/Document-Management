using Heinekamp.Application.Repositories;
using Heinekamp.Application.Services;
using Heinekamp.Persistence.EntityFramework.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Heinekamp.Persistence.EntityFramework.Context;
using Heinekamp.Persistence.EntityFramework.Services;
using Microsoft.AspNetCore.Builder;

namespace Heinekamp.Persistence.EntityFramework;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<HeinekampContext>(options =>
            options.UseInMemoryDatabase("Default"));

        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

        services.AddScoped<IDocumentService, DocumentService>();


        return services;
    }

    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();

        var context = serviceScope.ServiceProvider.GetRequiredService<HeinekampContext>();

        HeinekampContext.SeedData(context);

        return app;
    }

}