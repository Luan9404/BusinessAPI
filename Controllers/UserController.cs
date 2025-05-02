using System.Threading.Tasks;
using Api.Entities;
using Api.Models.Request;
using Api.Models.Response;
using Api.Service.Interface;
using Api.Service.Models.Response;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
  private readonly IUserService _userService;

  public UserController(IUserService userService)
  {
    _userService = userService;
  }

  [HttpGet("{Id}")]
  public IActionResult GetUser([FromRoute] long Id)
  {
    User result = _userService.GetUser(Id);

    Response<User> response = new(result);

    return Ok(response);
  }

  [HttpPost]
  public IActionResult CreateUser([FromBody] CreateUserRequest request)
  {
    return Ok();
  }
}