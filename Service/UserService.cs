using System.Threading.Tasks;
using BusinessAPI.Domain.Entities;
using BusinessAPI.Domain.Repository.Interface;
using BusinessAPI.Service.Interface;
using BusinessAPI.Service.Models.Result;
using Microsoft.AspNetCore.Http.HttpResults;
using BusinessAPI.Service.Models.Result;
using BusinessAPI.Service.Models.Request;

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
    throw new NotImplementedException();
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
}
