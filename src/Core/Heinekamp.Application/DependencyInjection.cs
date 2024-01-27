using System.Reflection;
using FluentValidation;
using Heinekamp.Application.Features.DocumentTypes.Queries.GetDocumentTypes;
using Microsoft.Extensions.DependencyInjection;

namespace Heinekamp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
                .AddMediatR(configuration =>
                {
                    configuration.RegisterServicesFromAssemblyContaining(typeof(GetDocumentTypesHandler));
                });
        }
    }
}
