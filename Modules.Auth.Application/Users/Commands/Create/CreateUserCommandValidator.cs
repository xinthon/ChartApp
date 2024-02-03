using FluentValidation;
using FluentValidation.Results;

namespace Modules.Auth.Application.Users.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(p => p.Username)
                .NotNull()
                .NotEmpty()
                .WithName("username");

            RuleFor(p => p.Email)
                .NotNull()
                .NotEmpty()
                .WithName("email");

            RuleFor(p => p.Password)
                .NotNull()
                .NotEmpty()
                .WithName("password");
        }
    }
}
