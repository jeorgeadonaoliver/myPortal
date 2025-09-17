using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using myPortal.Authentication.Application.Abstraction.Authentication;
using myPortal.Authentication.Application.Abstraction.Data;
using myPortal.Authentication.Application.Abstraction.Request;
using myPortal.Authentication.Infrastructure.Authentication;
using myPortal.Authentication.Infrastructure.PortalDb;
using myPortal.Authentication.Infrastructure.Request;

namespace myPortal.Authentication.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddRequestService(this IServiceCollection service)
    {
        service.AddScoped(typeof(RequestHandlerWrapper<,>));

        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var handlerInterfaceType = typeof(IRequestHandler<,>);

        var handlerTypes = assemblies
            .SelectMany(a => a.GetTypes())
            .Where(t => !t.IsAbstract && !t.IsInterface)
            .Select(t => new
            {
                ServiceType = t.GetInterfaces()
                    .FirstOrDefault(i => i.IsGenericType && i.GetGenericTypeDefinition() == handlerInterfaceType),
                ImplementationType = t
            })
            .Where(x => x.ServiceType != null);

        foreach (var type in handlerTypes)
        {
            service.AddTransient(type.ServiceType, type.ImplementationType);

            var requestType = type.ServiceType.GenericTypeArguments[0];
            var responseType = type.ServiceType.GenericTypeArguments[1];
            var wrapperClosedType = typeof(RequestHandlerWrapper<,>).MakeGenericType(requestType, responseType);
            service.AddTransient(typeof(IRequestHandlerWrapper), wrapperClosedType);
        }

        service.AddScoped<IRequestDispatcher, RequestDispatcher>();

        return service;
    }

    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        FirebaseApp.Create(new AppOptions
        {
            Credential = GoogleCredential.FromFile("firebase.json")
        });

        return services;
    }

    public static IServiceCollection AddPortalDbServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<MyPortalDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("PortalDb")));

        services.AddScoped<IMyPortalDbContext>(provider => provider.GetRequiredService<MyPortalDbContext>());
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IMfaService, MfaService>();

        services.AddHttpClient<IJwtService, JwtService>((sp, client) =>
        {
            var configuration = sp.GetRequiredService<IConfiguration>();

            client.BaseAddress = new Uri(uriString: configuration["Authentication:TokenUri"]);
        });

        return services;
    }

    public static IServiceCollection AddFirebaseServices(this IServiceCollection services, IConfiguration config)
    {
        var firebaseProjectId = config["Firebase:ProjectId"];

        services
            .AddAuthentication("Bearer")
            .AddJwtBearer("Bearer",options =>
            {
                options.Authority = $"https://securetoken.google.com/{firebaseProjectId}";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = $"https://securetoken.google.com/{firebaseProjectId}",
                    ValidateAudience = true,
                    ValidAudience = firebaseProjectId,
                    ValidateLifetime = true
                };
            });

        return services;
    }
}
