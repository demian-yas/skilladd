using Skilladd.Domain.Hiring.Enum.EnumCompany;

namespace Skilladd.Application.Company.CreateCompany;

public record CreateCompanyRequest(Guid ownerId ,string name, string slug, string? description, string? logoUrl, string? website, string? industry,
    CompanySize? size, CreateCompanyAddressRequest? address ,CreateCompanyLocationRequest? location);

public record CreateCompanyAddressRequest(string? country, string? city, string? street);

public record CreateCompanyLocationRequest(double latitude, double longitude); 