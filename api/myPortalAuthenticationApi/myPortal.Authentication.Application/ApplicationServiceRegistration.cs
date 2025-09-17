using Microsoft.Extensions.DependencyInjection;
using myPortal.Authentication.Application.Abstraction.Helper;
using myPortal.Authentication.Application.Helper;

namespace myPortal.Authentication.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IValidationHelper, ValidationHelper>();
        services.AddScoped<IRandomKeyHelper, RandomKeyHelper>();

        return services;
    }

}
