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
        if (string.IsNullOrWhiteSpace(country))
            return Result.Failure<Address>("Address cannot be empty or have spaces");

        if (string.IsNullOrWhiteSpace(city))
            return Result.Failure<Address>("City cannot be empty or have spaces");
        
        if (string.IsNullOrWhiteSpace(street))
            return Result.Failure<Address>("Street cannot be empty or have spaces");
        
        return Result.Success(new Address(country, city, street));
    }
}