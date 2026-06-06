using Skilladd.Domain.Common;

namespace Skilladd.Domain.Hiring.VO;

public sealed record CompanyId : MethodsId
{
    private CompanyId(Guid value) : base(value){}
    
    public static CompanyId NewCompanyId() => new(Guid.NewGuid());
    
    public static CompanyId Empty() => new(Guid.Empty);

    public static CompanyId Create(Guid id) => new(id);
}