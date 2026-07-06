using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Skilladd.Application.Company.CreateCompany;

namespace Skilladd.Application;

public static class Inject
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<CreateCompanyHandler>();
        
        services.AddValidatorsFromAssembly(typeof(Inject).Assembly);
        
        return services;
    }
}