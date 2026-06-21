using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Skilladd.Application.Company;
using Skilladd.Infrastructure.Repositories.HairingRepositories;

namespace Skilladd.Infrastructure;

public static class Inject
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ApplicationDbContext>();

        services.AddScoped<ICompanyRepository, CompanyRepository>();
        
        return services;
    }
}