using CSharpFunctionalExtensions;
using Skilladd.Domain.Common;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Application.Company.CreateCompany;

public class CreateCompanyHandler
{
    private readonly ICompanyRepository _companyRepository;

    public CreateCompanyHandler(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }
    
    public async Task<Result<Guid, Error>> CreateAsync(CreateCompanyRequest request,
        CancellationToken cancellationToken = default)
    {
        var companyExist = await _companyRepository.GetCompanyByNameAsync(request.name);
        if (companyExist.IsSuccess)
            return Errors.Company.CompanyAlreadyExist(request.name);
        
        var companyId = CompanyId.NewCompanyId();
        
        var address = Address.Create(
            request.address.country,
            request.address.city,
            request.address.street);

        var location = Location.Create(
            request.location.latitude,
            request.location.longitude);

        if (location.IsFailure)
            return location.Error;


        var company = Domain.Hiring.Classes.Company.Create(
            companyId,
            request.ownerId,
            request.name,
            request.slug,
            request.description,
            request.logoUrl,
            request.website,
            request.industry,
            request.size,
            address.Value,
            location.Value,
            request.createdAt
        );
        
        if (company.IsFailure)
            return company.Error;
        
        await _companyRepository.AddCompanyAsync(company.Value, cancellationToken);
        
        return companyId.Value;
    }
}