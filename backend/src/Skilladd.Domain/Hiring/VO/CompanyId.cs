namespace Skilladd.Domain.Hiring.VO;

public sealed record CompanyId
{
    private CompanyId(Guid value)
    {
        Value = value;
    }
    
    public Guid Value { get; }
    
    public static CompanyId NewCompanyId() => new(Guid.NewGuid());
    
    public static CompanyId Empty() => new(Guid.Empty);

    public static CompanyId Create(Guid id) => new(id);
}