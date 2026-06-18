namespace Skilladd.Application.Company;

public interface ICompanyRepository
{
    public Task AddCompanyAsync(Domain.Hiring.Classes.Company company, CancellationToken cancellationToken = default);
}