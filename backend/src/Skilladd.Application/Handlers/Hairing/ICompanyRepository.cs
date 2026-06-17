using Skilladd.Domain.Hiring.Classes;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Application.Handlers.Hairing;

public interface ICompanyRepository
{
    public Task<Company?> GetCompanyById(CompanyId id);

    public Task AddCompany(Company company, CancellationToken cancellationToken = default);
}