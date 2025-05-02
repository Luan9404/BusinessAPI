using System.ComponentModel.DataAnnotations;

namespace Api.Models.Request;

public class CreateUserRequest
{
  public string Name { get; set; }
  public string Email { get; set; }
  public string Phone { get; set; }
  public string Login { get; set; }
  public string Password { get; set; }
}