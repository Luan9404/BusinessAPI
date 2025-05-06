using BusinessAPI.Api.Models.Request;
using ServiceRequest = BusinessAPI.Service.Models.Request;
namespace BusinessAPI.Api.Mapping;

public class UserMapper
{
  public ServiceRequest.CreateUserRequest Map(CreateUserRequest request)
  {
    return new ServiceRequest.CreateUserRequest
    {
      Login = request.Login,
      Email = request.Email,
      Name = request.Name,
      Password = request.Password,
      Phone = request.Phone
    };
  }
  public ServiceRequest.UpdateUserRequest Map(UpdateUserRequest request)
  {
    return new ServiceRequest.UpdateUserRequest
    {
      UserId = request.GetUserId(),
      Login = request.Login,
      Email = request.Email,
      Name = request.Name,
      Password = request.Password,
      Phone = request.Phone
    };
  }
}