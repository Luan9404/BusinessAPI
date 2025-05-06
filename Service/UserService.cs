using System.Threading.Tasks;
using BusinessAPI.Domain.Entities;
using BusinessAPI.Domain.Repository.Interface;
using BusinessAPI.Service.Interface;
using BusinessAPI.Service.Models.Result;
using Microsoft.AspNetCore.Http.HttpResults;
using BusinessAPI.Service.Models.Result;
using BusinessAPI.Service.Models.Request;
using BusinessAPI.Utils;
using BusinessAPI.Utils.Models.CustomExceptions;

namespace BusinessAPI.Service;

public class UserService : IUserService
{
  private readonly IUserRepository _userRepository;
  public UserService(IUserRepository userRepository)
  {
    _userRepository = userRepository;
  }
  public CreateUserResult CreateUser(CreateUserRequest request)
  {
    User user = new()
    {
      Login = request.Login,
      Email = request.Email,
      Name = request.Name,
      Phone = request.Phone,
      UserCredential = new()
      {
        Password = CryptoHelper.Encrypt(request.Password),
      }
    };

    User createUserResult = _userRepository.Create(user);

    CreateUserResult result = new()
    {
      UserId = createUserResult.UserId,
    };

    return result;
  }

  public User GetUser(long id)
  {
    if (id == default)
      throw new Exception();

    User user = _userRepository.GetById(id);
    if (user == null)
      throw new Exception();

    return user;
  }

  public void UpdateUser(UpdateUserRequest request)
  {
    User user = _userRepository.GetById(request.UserId);
    if (user == null)
      throw new ValidationException("User not found");

    user.Name = request.Name ?? user.Name;
    user.Email = request.Email ?? user.Email;
    user.Phone = request.Phone ?? user.Phone;
    user.Login = request.Login ?? user.Login;

    if (!string.IsNullOrEmpty(request.Password))
      user.UserCredential.Password = CryptoHelper.Encrypt(request.Password);

    _userRepository.Update(user);
  }
}
