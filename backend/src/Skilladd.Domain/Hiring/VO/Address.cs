using CSharpFunctionalExtensions;

namespace Skilladd.Domain.Hiring.VO;

public sealed record Address
{ 
    private Address(string? country, string? city, string? street)
    {
        Country = country;
        City = city;
        Street = street;
    }
    
    public string? Country { get; }
    public string? City { get; }
    public string? Street { get; }

    public static Result<Address> Create(string? country, string? city, string? street)
    {
        return Result.Success(new Address(country, city, street));
    }
}