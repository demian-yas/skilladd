using CSharpFunctionalExtensions;

namespace Skilladd.Domain.Hiring;

public class JobPost
{
    
    private JobPost(){}

    public JobPost(Guid authorId, Guid companyId, string title, 
        string description, string requirements, decimal? salaryFrom, 
        decimal? salaryTo, string currency, string[] skills, 
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
        Skills = skills;
        ExpiresAt = expiresAt;
        CreatedAt = DateTime.UtcNow;
    }
    
    public Guid Id { get; private set; }
    
    public Company Company { get; private set; }
    public Guid CompanyId { get; private set; }
    
    public Guid AuthorId { get; private set; }
    
    public string Title { get; private set; } = null!;
    
    public string Description { get; private set; } = null!;
    
    public string Requirements { get; private set; } = null!;
    
    public decimal? SalaryFrom { get; private set; }
    
    public decimal? SalaryTo { get; private set; }
    
    public string Currency { get; private set; } = null!;
    
    //public enum Employment { get; set; }
    
    //public enum Format { get; set; }
    
    public string[] Skills { get; private set; } = null!;
    
    //public enum Status { get; set; }
    
    public DateTime? ExpiresAt { get; private set; }
    
    public DateTime CreatedAt { get; private set; }

    public static Result<JobPost> Create(Guid authorId, Guid companyId, string title,
        string description, string requirements, decimal? salaryFrom,
        decimal? salaryTo, string currency, string[] skills,
        DateTime? expiresAt)
    {
        // валидация
        var jobPostResult = new JobPost(authorId, companyId, title,
            description, requirements, salaryFrom,
            salaryTo, currency, skills,
            expiresAt);
        
        return Result.Success(jobPostResult);
    }
    
}