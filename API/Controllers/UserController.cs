
using BusinessAPI.Service.Interface;
using BusinessAPI.Service.Models.Result;
using BusinessAPI.Api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BusinessAPI.Api.Models.Response;
using BusinessAPI.Api.Models.Request;
using BusinessAPI.Domain.Entities;
using BusinessAPI.Api.Utils;
namespace BusinessAPI.Api.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
  private readonly IUserService _userService;
  private readonly IValidator<CreateUserRequest> _createUserValidator;
  public UserController(IUserService userService, IServiceProvider serviceProvider)
  {
    _userService = userService;
    _createUserValidator = serviceProvider.GetService<IValidator<CreateUserRequest>>();
  }

  [HttpGet("{Id}")]
  public IActionResult GetUser([FromRoute] long Id)
  {

    User result = _userService.GetUser(Id);
    Response<User> response = new(result);

    return Ok(response);
  }

  /// <summary>
  /// 
  /// </summary>
  /// <param name="request">Request Body</param>
  /// <returns></returns>
  [HttpPost]
  public IActionResult CreateUser([FromBody] CreateUserRequest request)
  {
    var validateResult = _createUserValidator.Validate(request);

    if (!validateResult.IsValid)
      ValidationHelper.ThrowErrors(validateResult);

    return Ok();
  }
}