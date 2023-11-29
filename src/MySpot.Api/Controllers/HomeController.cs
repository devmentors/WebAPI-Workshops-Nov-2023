using Microsoft.AspNetCore.Mvc;

namespace MySpot.Api.Controllers;

[Route("api")]
public class HomeController : ControllerBase
{
    [HttpGet("hello")]
    public ActionResult<string> Get()
    {
        return "MySpot API";
    }
}