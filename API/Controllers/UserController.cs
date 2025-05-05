
using BusinessAPI.Service.Interface;
using BusinessAPI.Service.Models.Result;
using BusinessAPI.Api.Validators;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using BusinessAPI.Api.Models.Response;
using BusinessAPI.Api.Models.Request;
using BusinessAPI.Domain.Entities;
using BusinessAPI.Api.Utils;
using ServiceRequest = BusinessAPI.Service.Models.Request;
using BusinessAPI.Api.Mapping;
namespace BusinessAPI.Api.Controllers;

[Route("[controller]")]
public class UserController : Controller
{
  private readonly IUserService _userService;
  private readonly IValidator<CreateUserRequest> _createUserValidator;
  private readonly IValidator<GetUserByIdRequest> _getUserByIdValidator;
  private readonly UserMapper _mapper;
  public UserController(IUserService userService, IServiceProvider serviceProvider)
  {
    _userService = userService;
    _createUserValidator = serviceProvider.GetService<IValidator<CreateUserRequest>>();
    _getUserByIdValidator = serviceProvider.GetService<IValidator<GetUserByIdRequest>>();
    _mapper = new();
  }
  /// <summary>
  /// 
  /// </summary>
  /// <param name="Id">UserId</param>
  /// <returns></returns>
  [HttpGet("{Id}")]
  public IActionResult GetUser([FromRoute] long Id)
  {
    GetUserByIdRequest request = new() { UserId = Id };
    var validateResult = _getUserByIdValidator.Validate(request);

    if (!validateResult.IsValid)
      ValidationHelper.ThrowErrors(validateResult);

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

    ServiceRequest.CreateUserRequest serviceRequest = _mapper.Map(request);
    CreateUserResult result = _userService.CreateUser(serviceRequest);

    Response<CreateUserResult> response = new(result);

    return Ok(response);
  }
}