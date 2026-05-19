using CSharpFunctionalExtensions;
using Skilladd.Domain.Hiring.Enum.EnumJobPost;

namespace Skilladd.Domain.Hiring.Classes;

public class JobPost
{
    
    private JobPost(){}

    private JobPost(Guid authorId, Guid companyId, string title, 
        string description, string requirements, decimal? salaryFrom, 
        decimal? salaryTo, string currency, EnumEmployment employment,
        EnumFormat format, EnumStatus status, List<string> skills, 
        DateTime? expiresAt)
    {
        Id = Guid.NewGuid();
        AuthorId = authorId;
        CompanyId = companyId;
        Title = title;
        Description = description;
        Requirements = requirements;
        SalaryFrom = salaryFrom;
        SalaryTo = salaryTo;
        Currency = currency;
        Employment = employment;
        Format = format;
        Status = status;
        Skills = skills;
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
    
    public decimal? SalaryFrom { get; private set; }
    
    public decimal? SalaryTo { get; private set; }
    
    public string Currency { get; private set; } = null!;
    
    public EnumEmployment Employment { get; private set; }
    
    public EnumFormat Format { get; private set; }
    
    public List<string> Skills { get; private set; } = null!;
    
    public EnumStatus Status { get; private set; }
    
    public DateTime? ExpiresAt { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public static Result<JobPost> Create(Guid authorId, Guid companyId, string title, 
        string description, string requirements, decimal? salaryFrom, 
        decimal? salaryTo, string currency, EnumEmployment employment,
        EnumFormat format, EnumStatus status, List<string> skills, 
        DateTime? expiresAt)
    {
        
        if(string.IsNullOrWhiteSpace(title))
            return Result.Failure<JobPost>("Title is required");
        if(string.IsNullOrWhiteSpace(description))
            return Result.Failure<JobPost>("Description is required");
        if(string.IsNullOrWhiteSpace(requirements))
            return Result.Failure<JobPost>("Requirements is required");
        
        var jobPostResult = new JobPost(authorId, companyId, title,
            description, requirements, salaryFrom,
            salaryTo, currency, employment, format, status, skills,
            expiresAt);
        
        return Result.Success(jobPostResult);
    }
    
}