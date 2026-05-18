namespace Skilladd.Domain;

public class Job
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public Guid AuthorId { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Requirements { get; set; } = null!;
    public decimal? SalaryFrom { get; set; }
    public decimal? SalaryTo { get; set; }
    public string Currency { get; set; } = null!;
    //public enum Employment { get; set; }
    //public enum Format { get; set; }
    public string[] Skills { get; set; } = null!;
    //public enum Status { get; set; }
    public DateTime? ExpiresAt { get; set; }
    public DateTime CreatedAt { get; set; }
}