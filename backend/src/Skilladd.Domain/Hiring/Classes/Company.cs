using CSharpFunctionalExtensions;
using Skilladd.Domain.Hiring.Enum.EnumCompany;

namespace Skilladd.Domain.Hiring.Classes;

public class Company
{
    private readonly List<JobPost> _jobPosts = [];
    
    // ef core
    private Company() { }

    private Company(Guid ownerId ,string name, string slug, string? description, string? logoUrl, string? website, string? industry,
        CompanySize? size, string? location, DateTime createdAt)
    {
        Id = Guid.NewGuid();
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
    
    public Guid Id { get; private set; }
    
    public Guid OwnerId { get; private set; }
    
    public string Name { get; private set; } = null!;
    
    public string Slug { get; private set; } = null!;
    
    public string? Description { get; private set; }
    
    public string? LogoUrl { get; private set; } 
    
    public string? Website { get; private set; }
    
    public string? Industry { get; private set; }
    
    public CompanySize? Size { get; set; }
    
    public string? Location { get; private set; }
    
    public bool IsVerified { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<JobPost> JobPosts => _jobPosts;

    public int JobPostsCount => JobPosts.Count;

    public static Result<Company> Create(Guid ownerId, string name, string slug, string? description, string? logoUrl, string? website,
        string? industry, CompanySize? size,
        string? location, DateTime createdAt)
    {
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
            return Result.Failure<Company>("Industry cannot be null or with whitespace");
        
        if (string.IsNullOrWhiteSpace(location))
            return Result.Failure<Company>("Location cannot be null or with whitespace");
        
        var company = new Company(ownerId ,name, slug, description, logoUrl, website, industry,
            size, location, createdAt);
        
        return Result.Success(company);
    }
}