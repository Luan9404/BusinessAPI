using BusinessAPI.Api.Models.Request;
using FluentValidation;

namespace BusinessAPI.Api.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
  public CreateUserRequestValidator()
  {
    RuleFor(x => x.Login).NotEmpty();
    RuleFor(x => x.Email)
      .NotEmpty()
      .EmailAddress();
    RuleFor(x => x.Name).NotEmpty();
    RuleFor(x => x.Password)
      .NotEmpty()
      .MinimumLength(8);
    RuleFor(x => x.Phone)
      .NotEmpty()
      .Length(11)
      .Matches(@"^\d+$")
      .WithMessage("Phone number must contain only numbers.");
  }
}