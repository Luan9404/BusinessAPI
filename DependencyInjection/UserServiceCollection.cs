using Api.Repository;
using Api.Repository.Interface;
using Api.Service;
using Api.Service.Interface;

namespace Api.DependencyInjection;

public static class UserServiceCollection
{
  public static void AddUserServices(this IServiceCollection service)
  {
    service.AddScoped<IUserRepository, UserRepository>();
    service.AddScoped<IUserService, UserService>();
  }
}