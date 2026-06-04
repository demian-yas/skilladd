using CSharpFunctionalExtensions;
using Skilladd.Domain.Hiring.Enum.EnumJobPost;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Domain.Hiring.Classes;

public class JobPost
{
    private readonly List<string> _skills = [];
    
    // ef core
    private JobPost(){}

    private JobPost(Guid authorId, Guid companyId, string title, 
        string description, string requirements, Offer offer,EnumEmployment employment,
        EnumFormat format, List<string> skills, 
        DateTime? expiresAt)
    {
        Id = Guid.NewGuid();
        AuthorId = authorId;
        CompanyId = companyId;
        Title = title;
        Description = description;
        Requirements = requirements;
        Offer = offer;
        Employment = employment;
        Format = format;
        Status = EnumStatus.Draft;
        _skills.AddRange(skills);
        ExpiresAt = expiresAt;
        CreatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    
    public Company? Company { get; private set; }
    public Guid CompanyId { get; private set; }
    
    public Guid AuthorId { get; private set; }
    
    public string Title { get; private set; } = null!;
    
    public string Description { get; private set; } = null!;
    
    public string Requirements { get; private set; } = null!;
    
    public Offer Offer { get; private set; }
    
    public EnumEmployment Employment { get; private set; }
    
    public EnumFormat Format { get; private set; }
    
    public IReadOnlyList<string> Skills =>  _skills;
    
    public EnumStatus Status { get; private set; }
    
    public DateTime? ExpiresAt { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public static Result<JobPost> Create(Guid authorId, Guid companyId, string title, 
        string description, string requirements, decimal? salaryFrom, 
        decimal? salaryTo, string currency, EnumEmployment employment,
        EnumFormat format, List<string> skills, 
        DateTime? expiresAt)
    {
        
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<JobPost>("Title is required");
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<JobPost>("Description is required");
        if(string.IsNullOrWhiteSpace(requirements))
            return Result.Failure<JobPost>("Requirements is required");

        var offerResult = Offer.Create(salaryFrom, salaryTo, currency);
        if(offerResult.IsFailure)
            return Result.Failure<JobPost>(offerResult.Error);
        
        var jobPostResult = new JobPost(authorId, companyId, title,
            description, requirements, offerResult.Value, employment, format, skills,
            expiresAt);
        
        return Result.Success(jobPostResult);
    }
    
}