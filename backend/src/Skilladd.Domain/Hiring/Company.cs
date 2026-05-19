using CSharpFunctionalExtensions;

namespace Skilladd.Domain.Hiring;

public class Company
{
    private readonly List<JobPost> _jobPosts = [];
    
    // ef core
    private Company() { }

    public Company(Guid ownerId ,string name, string slug, string description, string logoUrl, string website, string industry,
        string location, DateTime createdAt)
    {
        Id = Guid.NewGuid();
        OwnerId = ownerId;
        Name = name;
        Slug = slug;
        Description = description;
        LogoUrl = logoUrl;
        Website = website;
        Industry = industry;
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
    
    // public enum? Size { get; set; }
    
    public string? Location { get; private set; }
    
    public bool IsVerified { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<JobPost> JobPosts => _jobPosts;

    public int JobPostsCount => JobPosts.Count;

    public static Result<Company> Create(Guid ownerId, string name, string slug, string description, string logoUrl, string website,
        string industry,
        string location, bool isVerified, DateTime createdAt)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Result.Failure<Company>("Name validation");
        if (string.IsNullOrWhiteSpace(slug))
            return Result.Failure<Company>("Slug validation");
        if (string.IsNullOrWhiteSpace(description))
            return Result.Failure<Company>("Description validation");
        if (string.IsNullOrWhiteSpace(logoUrl))
            return Result.Failure<Company>("Logo URL validation");
        if (string.IsNullOrWhiteSpace(website))
            return Result.Failure<Company>("Website validation");
        if (string.IsNullOrWhiteSpace(industry))
            return Result.Failure<Company>("Industry validation");
        if (string.IsNullOrWhiteSpace(location))
            return Result.Failure<Company>("Location validation");
        
        var company = new Company(ownerId ,name, slug, description, logoUrl, website, industry,
            location, createdAt);
        
        return Result.Success(company);
    }
}