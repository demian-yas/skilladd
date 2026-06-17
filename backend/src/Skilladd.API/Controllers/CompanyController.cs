using Microsoft.AspNetCore.Mvc;
using Skilladd.Domain.Hiring.Classes;
using Skilladd.Domain.Hiring.VO;

namespace Skilladd.API.Controllers;

[ApiController]
[Route("api")]
public class CompanyController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get(string title, string slug)
    {
        return Ok();
    }
}