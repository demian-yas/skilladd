using Microsoft.AspNetCore.Mvc;
using Skilladd.Domain.Hiring.Classes;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.API.Controllers;

[ApiController]
[Route("api")]
public class CompanyController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddCompanyAsync()
    {
        return Ok();
    }
}