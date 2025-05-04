using BusinessAPI.Utils.Models.CustomExceptions;
using FluentValidation.Results;

namespace BusinessAPI.Api.Utils;

public static class ValidationHelper
{
  public static void ThrowErrors(ValidationResult result)
  {
    var errors = result.Errors
    .Select(e => new
    {
      Field = e.PropertyName,
      Message = e.ErrorMessage
    })
    .ToList();

    throw new ValidationException("Validation failed", errors);
  }
}
