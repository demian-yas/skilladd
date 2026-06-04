using CSharpFunctionalExtensions;

namespace Skilladd.Domain.Hiring.VO;

public sealed record Offer
{
    private Offer(decimal? salaryFrom, decimal? salaryTo, string currency)
    {
        SalaryFrom =  salaryFrom;
        SalaryTo =   salaryTo;
        Currency = currency;
    }
    
    public decimal? SalaryFrom { get; }
    
    public decimal? SalaryTo { get; }
    
    public string Currency { get; }

    public static Result<Offer> Create(decimal? salaryFrom, decimal? salaryTo, string currency)
    {
        if (salaryFrom >= salaryTo)
            return Result.Failure<Offer>("the minimum salary cannot be greater than the maximum salary");
        
        if (salaryFrom.HasValue && salaryFrom< 0)
            return Result.Failure<Offer>("the minimum salary cannot be negative");
        if (salaryTo.HasValue && salaryTo < 0)
            return Result.Failure<Offer>("the maximum salary cannot be negative");
        
        if (string.IsNullOrWhiteSpace(currency))
            return Result.Failure<Offer>("Currency cannot be empty or have spaces");

        return Result.Success(new Offer(salaryFrom, salaryTo, currency));
    }
}