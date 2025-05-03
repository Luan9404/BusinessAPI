using BusinessAPI.Domain.Repository;
using BusinessAPI.Domain.Repository.Interface;
using BusinessAPI.Service;
using BusinessAPI.Service.Interface;

namespace BusinessAPI.Service.DependencyInjection;

public static class UserServiceCollection
{
  public static void AddUserServices(this IServiceCollection service)
  {
    service.AddScoped<IUserService, UserService>();
  }
}