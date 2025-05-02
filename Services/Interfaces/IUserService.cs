using Api.Entities;
using Api.Models.Request;
using Api.Service.Models.Response;

namespace Api.Service.Interface;

public interface IUserService
{
  public User GetUser(long id);
  public CreateUserResult CreateUser(CreateUserRequest request);
}
