using BusinessAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BusinessAPI.Domain;

public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
  public DbSet<User> User { get; set; }
  public DbSet<UserCredential> UserCredential { get; set; }
}