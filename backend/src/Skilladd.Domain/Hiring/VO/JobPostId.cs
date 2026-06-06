using Skilladd.Domain.Common;

namespace Skilladd.Domain.Hiring.VO;

public sealed record JobPostId : MethodsId
{
    private JobPostId(Guid value) : base(value){}
    
    public static JobPostId NewJobPostId() => new(Guid.NewGuid());
    
    public static JobPostId Empty() => new(Guid.Empty);

    public static JobPostId Create(Guid id) => new(id);
}