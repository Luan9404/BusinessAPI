using BusinessAPI.Domain.Repository;
using BusinessAPI.Domain.Repository.Interface;

namespace BusinessAPI.Domain.DependencyInjection;

public static class UserServiceCollection
{
  public static void AddUserDomain(this IServiceCollection service)
  {
    service.AddScoped<IUserRepository, UserRepository>();
  }
}