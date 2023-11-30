using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MySpot.Infrastructure;

namespace MySpot.Api.Controllers;

[Route("api")]
public class HomeController : ControllerBase
{
    private readonly string? _apiName;

    public HomeController(IOptions<ApiOptions> options)
    {
        _apiName = options.Value.Name;
    }

    [HttpGet("hello")]
    public ActionResult<string> Get() => _apiName;
    
    [HttpGet("error")]
    public ActionResult<string> Error() => throw new Exception("ooops");
}