using Microsoft.Extensions.DependencyInjection;
using Skilladd.Application.Company.CreateCompany;

namespace Skilladd.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateCompanyHandler>();
        
        return services;
    }
}