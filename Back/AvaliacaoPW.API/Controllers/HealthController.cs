using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoPW.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HealthController : ControllerBase
{
    [HttpGet]
    public ActionResult<string> Get()
    {
        return Ok(new
        {
            Message = "Welcome to AvaliacaoPW API",
            AccessDate = DateTime.Now.ToLongDateString(),
        });
    }
}