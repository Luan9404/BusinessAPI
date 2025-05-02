using System.Threading.Tasks;
using Api.Entities;
using Api.Models.Request;
using Api.Repository.Interface;
using Api.Service.Interface;
using Api.Service.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Api.Service;

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
