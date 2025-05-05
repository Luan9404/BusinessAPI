using BusinessAPI.Api.Models.Request;
using FluentValidation;

namespace BusinessAPI.Api.Validators;

public class GetUserByIdRequestValidator : AbstractValidator<GetUserByIdRequest>
{
  public GetUserByIdRequestValidator()
  {
    RuleFor(x => x.UserId)
      .NotEmpty()
      .WithMessage("UserId is required.")
      .GreaterThan(0)
      .WithMessage("Id must be greater than 0.");
  }
}