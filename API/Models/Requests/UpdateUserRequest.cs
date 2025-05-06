namespace BusinessAPI.Api.Models.Request;

public class UpdateUserRequest
{
  private long UserId { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
  public void InsertUserId(long userId)
  {
    UserId = userId;
  }
  public long GetUserId()
  {
    return UserId;
  }
}
