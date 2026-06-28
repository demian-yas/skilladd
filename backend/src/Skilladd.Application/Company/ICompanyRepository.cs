using CSharpFunctionalExtensions;
using Skilladd.Domain.Common;

namespace Skilladd.Application.Company;
using Skilladd.Domain.Hiring.Classes;

public interface ICompanyRepository
{
    public Task AddCompanyAsync(Company company, CancellationToken cancellationToken = default);

    public Task<Result<Company, Error>> GetCompanyByNameAsync(string name);
}