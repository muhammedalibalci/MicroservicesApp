using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{

    [HttpGet]
    public bool Test()
    {
        return true;
    }
}