using CSharpFunctionalExtensions;
using Skilladd.Domain.Hiring.Enum.EnumCompany;
using Skilladd.Domain.Hiring.VO;
    
namespace Skilladd.Domain.Hiring.Classes;

public class Company : Common.Entity<CompanyId>
{
    private readonly List<JobPost> _jobPosts = [];
    
    // ef core
    private Company(CompanyId id) : base(id)
    {
    }

    private Company(CompanyId companyId, Guid ownerId ,string name, string slug, string? description, string? logoUrl, string? website, string? industry,
        CompanySize? size, Location? location, DateTime createdAt) : base(companyId)
    {
        OwnerId = ownerId;
        Name = name;
        Slug = slug;
        Description = description;
        LogoUrl = logoUrl;
        Website = website;
        Industry = industry;
        Size = size;
        Location = location;
        IsVerified = false;
        CreatedAt = createdAt;
    }
    
    public Guid OwnerId { get; private set; }
    
    public string Name { get; private set; } = null!;
    
    //URL короткое
    public string Slug { get; private set; } = null!;
    
    public string? Description { get; private set; }
    
    public string? LogoUrl { get; private set; }
    //сайт компании
    public string? Website { get; private set; }
    
    public string? Industry { get; private set; }
    
    public CompanySize? Size { get; private set; }
    
    public Location? Location { get; private set; }
    
    public bool IsVerified { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<JobPost> JobPosts => _jobPosts;
    
    public static Result<Company> Create(CompanyId companyId,Guid ownerId, string name, string slug, string? description, string? logoUrl, string? website,
        string? industry, CompanySize? size, double? latitude, double? longitude, DateTime createdAt)
    {
        Location? location = null;
        
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Company>("Name cannot be null or with whitespace");
        
        if (string.IsNullOrWhiteSpace(slug))
            return Result.Failure<Company>("Slug cannot be null or with whitespace");
        
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Company>("Description cannot be null or with whitespace");
        
        if (string.IsNullOrWhiteSpace(logoUrl))
            return Result.Failure<Company>("LogoUrl cannot be null or with whitespace");
        
        if (string.IsNullOrWhiteSpace(website))
            return Result.Failure<Company>("Website cannot be null or with whitespace");
        
        if (string.IsNullOrWhiteSpace(industry))
            return Result.Failure<Company>("Industry cannot be null or with whitespace ");

        if (latitude.HasValue && longitude.HasValue)
        {
            var locationResult = Location.Create(latitude.Value, longitude.Value);
            
            if(locationResult.IsFailure)
                return Result.Failure<Company>(locationResult.Error);
            location = locationResult.Value;
        }
        
        var company = new Company(companyId, ownerId ,name, slug, description, logoUrl, website, industry,
            size, location, createdAt);
        
        return Result.Success(company);
    }
}