using System.Threading.Tasks;
using BusinessAPI.Domain.Entities;
using BusinessAPI.Domain.Repository.Interface;
using BusinessAPI.Utils.Models.CustomExceptions;
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

  public User Create(User user)
  {
    var result = _context.User.Add(user).Entity;

    _context.SaveChanges();

    return result;
  }

  public User GetById(long id)
  {
    var user = _context.User.SingleOrDefault(x => x.UserId == id);

    if (user == null)
      throw new NotFoundException("User not found");

    _context.Entry(user).Reference(x => x.UserCredential).Load();

    return user;
  }
}
