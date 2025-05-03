using BusinessAPI.Domain.Entities;
using BusinessAPI.Service.Models.Result;
using BusinessAPI.Service.Models.Request;
namespace BusinessAPI.Service.Interface;

public interface IUserService
{
  public User GetUser(long id);
  public CreateUserResult CreateUser(CreateUserRequest request);
}
