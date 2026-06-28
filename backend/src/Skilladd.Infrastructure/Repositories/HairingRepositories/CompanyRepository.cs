using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using Skilladd.Application.Company;
using Skilladd.Domain.Common;
using Skilladd.Domain.Hiring.Classes;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Infrastructure.Repositories.HairingRepositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly ApplicationDbContext _companyDbContext;
    
    public CompanyRepository(ApplicationDbContext context)
    {
        _companyDbContext = context;
    }
    
    public async Task<Company?> GetCompanyById(Guid id)
    {
        var company = await _companyDbContext.Companies.FirstOrDefaultAsync(x => x.Id.Value == id);
        return company;
    }

    public async Task<Result<Company, Error>> GetCompanyByNameAsync(string name)
    {
        var company = await _companyDbContext.Companies.FirstOrDefaultAsync(x => x.Name == name);

        if (company is null)
            return Errors.General.NotFound();
        
        return company;
    }

    public async Task AddCompanyAsync(Company company, CancellationToken cancellationToken = default)
    {
        await _companyDbContext.Companies.AddAsync(company, cancellationToken);
        await _companyDbContext.SaveChangesAsync(cancellationToken);
    }
}