using FluentValidation;
using Skilladd.Application.Validation;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.Application.Company.CreateCompany;

public class CreateCompanyRequestValidator : AbstractValidator<CreateCompanyRequest>
{
    public CreateCompanyRequestValidator()
    {
        // validation
    }
}