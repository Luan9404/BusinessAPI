namespace BusinessAPI.Domain.Entities;

public class UserCredential
{
  public long UserCredentialId { get; set; }
  public long UserId { get; set; }
  public required string Password { get; set; }
}