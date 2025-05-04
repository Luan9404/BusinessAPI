namespace BusinessAPI.Utils.Models.CustomExceptions;

public class NotFoundException : Exception
{
  public NotFoundException(string message) : base(message)
  {
    base.Data["StatusCode"] = 404;
  }

  public NotFoundException(string message, Exception innerException) : base(message, innerException)
  {
    base.Data["StatusCode"] = 404;
  }
}