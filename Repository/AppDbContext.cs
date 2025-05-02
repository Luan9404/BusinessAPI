using Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Repository;

public class AppDBContext : DbContext
{
  public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
  public DbSet<User> User { get; set; }
  public DbSet<UserCredential> UserCredential { get; set; }
}