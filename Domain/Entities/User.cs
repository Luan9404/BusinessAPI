namespace BusinessAPI.Domain.Entities;

public class User
{
  public long UserId { get; set; }
  public required string Name { get; set; }
  public required string Login { get; set; }
  public required string Email { get; set; }
  public required string Phone { get; set; }
  public UserCredential UserCredential { get; set; }
}