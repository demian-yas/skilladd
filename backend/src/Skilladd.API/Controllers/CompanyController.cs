using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Skilladd.API.Extensions;
using Skilladd.Application.Company.CreateCompany;
using Skilladd.Domain.Common;

namespace Skilladd.API.Controllers;

[ApiController]
[Route("api")]
public class CompanyController : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<Guid>> AddCompanyAsync(
        [FromServices] CreateCompanyHandler createCompanyHandler,
        [FromBody] CreateCompanyRequest request,
        CancellationToken cancellationToken = default)
    {
        var company = await createCompanyHandler.CreateAsync(request, cancellationToken);

        return company.ToResponse();
    }
}