using Api.Entities;

namespace Api.Repository.Interface;

public interface IUserRepository
{
  public User GetById(long id);
}