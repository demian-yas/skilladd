namespace Skilladd.Domain.Hiring.VO;

public sealed record JobPostId
{
    private JobPostId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    
    public static JobPostId NewJobPostId() => new(Guid.NewGuid());
    
    public static JobPostId Empty() => new(Guid.Empty);
}