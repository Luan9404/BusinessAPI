using Microsoft.AspNetCore.Mvc;

namespace BusinessAPI.Api.Controllers;

[Route("[controller]")]
public class AuthController : Controller
{
  [HttpPost("[action]")]
  public IActionResult Login([FromBody] object request)
  {
    return Ok();
  }
  [HttpPost("[action]")]
  public IActionResult ResetPassword([FromBody] object request)
  {
    return Ok();
  }
}