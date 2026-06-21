using CSharpFunctionalExtensions;
using Skilladd.Domain.Common;
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
        CompanySize? size, Address? address ,Location? location, DateTime createdAt) : base(companyId)
    {
        OwnerId = ownerId;
        Name = name;
        Slug = slug;
        Description = description;
        LogoUrl = logoUrl;
        Website = website;
        Industry = industry;
        Size = size;
        Address = address;
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
    
    public Address? Address { get; private set; }
    
    public Location? Location { get; private set; }
    
    public bool IsVerified { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public IReadOnlyList<JobPost> JobPosts => _jobPosts;
    
    public static Result<Company, Error> Create(CompanyId companyId,Guid ownerId, string name, string slug, string? description, string? logoUrl, string? website,
        string? industry, CompanySize? size, Address address, Location location, DateTime createdAt)
    {
        if (string.IsNullOrWhiteSpace(name))
            return Errors.General.ValueIsEmpty("name");

        if (string.IsNullOrWhiteSpace(slug))
            return Errors.General.ValueIsEmpty("slug");
        
        if (string.IsNullOrWhiteSpace(description))
            return Errors.General.ValueIsEmpty("description");

        if (string.IsNullOrWhiteSpace(logoUrl))
            return Errors.General.ValueIsEmpty("logoUrl");

        if (string.IsNullOrWhiteSpace(website))
            return Errors.General.ValueIsEmpty("website");

        if (string.IsNullOrWhiteSpace(industry))
            return Errors.General.ValueIsEmpty("industry");
        
        var company = new Company(companyId, ownerId ,name, slug, description, logoUrl, website, industry,
            size, address, location, createdAt);
        
        return company;
    }
}