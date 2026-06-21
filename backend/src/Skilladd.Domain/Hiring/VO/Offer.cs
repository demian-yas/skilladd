using CSharpFunctionalExtensions;
using Skilladd.Domain.Common;

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
    
    public string? Currency { get; }

    public static Result<Offer, Error> Create(decimal? salaryFrom, decimal? salaryTo, string currency)
    {
        if (salaryFrom < 0)
            return Errors.General.ValueIsInvalid("salaryFrom");
        
        if (salaryTo < 0)
            return Errors.General.ValueIsInvalid("salaryTo");
        
        if ((salaryFrom.HasValue && salaryTo.HasValue) && (salaryFrom.Value >= salaryTo.Value))
            return Errors.Offer.BusinessLogicIsInvalid();
        
        if (string.IsNullOrWhiteSpace(currency))
            return Errors.General.ValueIsEmpty("currency");

        return Result.Success<Offer, Error>(new Offer(salaryFrom, salaryTo, currency));
    }
}