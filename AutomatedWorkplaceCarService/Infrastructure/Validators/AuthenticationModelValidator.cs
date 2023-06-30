using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class AuthenticationModelValidator : AbstractValidator<AuthenticationViewModel>
    {
        public AuthenticationModelValidator()
        {
            this.RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Введите логин");
            this.RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Введите пароль");
        }
    }
}
