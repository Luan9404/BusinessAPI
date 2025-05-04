namespace BusinessAPI.Utils.Models.CustomExceptions;

public class ValidationException : Exception
{
  public ValidationException(string message) : base(message)
  {
    base.Data["StatusCode"] = 400;
  }

  public ValidationException(string message, dynamic errors) : base(message)
  {
    base.Data["StatusCode"] = 404;
    base.Data["Errors"] = errors;
  }

  public ValidationException(string message, Exception innerException) : base(message, innerException)
  {
    base.Data["StatusCode"] = 400;
  }
}