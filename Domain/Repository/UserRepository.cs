using System.Threading.Tasks;
using BusinessAPI.Domain.Entities;
using BusinessAPI.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BusinessAPI.Domain.Repository;

public class UserRepository : IUserRepository
{
  private readonly AppDBContext _context;

  public UserRepository(AppDBContext context)
  {
    _context = context;
  }

  public User GetById(long id)
  {
    return _context.User.Include(u => u.UserCredential).Single(x => x.UserId == id);
  }
}
