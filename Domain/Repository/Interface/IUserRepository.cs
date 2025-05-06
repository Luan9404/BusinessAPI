using BusinessAPI.Domain.Entities;

namespace BusinessAPI.Domain.Repository.Interface;

public interface IUserRepository
{
  public User GetById(long id);
  public User Create(User user);
  public void Update(User user);
}