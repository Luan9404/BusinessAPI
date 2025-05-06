namespace BusinessAPI.Service.Models.Request;

public class UpdateUserRequest
{
  public long UserId { get; set; }
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
}