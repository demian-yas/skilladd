namespace Skilladd.Domain.Common;

public class Errors
{
    public static class General
    {
        public static Error ValueIsInvalid(string? name = null)
        {
            var label = name ?? "value";

            return Error.Validation("value.is.invalid", $"{label} is invalid");
        }

        public static Error ValueIsEmpty(string? name = null)
        {
            var label = name ?? "input field";
            
            return Error.Validation("value.is.empty", $"{label} is empty");
        }

        public static Error NotFound(Guid? id = null)
        {
            var forId = id == null ? "" : $" for Id: {id} ";
            
            return Error.NotFound("record.not.found", $"record not found {forId}");
        }
    }

    public static class Offer
    {
        public static Error BusinessLogicIsInvalid(string? salaryFrom = null, string? salaryTo = null)
        {
            var forSalaryFrom = salaryTo ?? "salaryTo";
            var forSalaryTo = salaryFrom ?? "salaryFrom";
            
            return Error.Validation("business.logic.is.invalid", $"the {forSalaryFrom} cannot be greater than the {forSalaryTo}");
        }
    }

    public static class Company
    {
        public static Error CompanyAlreadyExist(string name)
            => Error.Validation("company.already.exist", $"company {name} already exists");
    }
}