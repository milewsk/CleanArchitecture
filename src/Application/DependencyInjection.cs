using Application.Abstractions.Behaviors;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services.AddMediator();
    }

    private static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly);

                configuration.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
                configuration.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            }
        );
        
        services.AddValidatorsFromAssembly(typeof(DependencyInjection).Assembly, includeInternalTypes: true);
        
        return services;
    }
}
