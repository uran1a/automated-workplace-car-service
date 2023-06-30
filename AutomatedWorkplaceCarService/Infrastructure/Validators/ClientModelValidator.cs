using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;
using System.Text.RegularExpressions;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class ClientModelValidator : AbstractValidator<ClientViewModel>
    {
        public ClientModelValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Введите имя");
            this.RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Минимальная длина имени - 3 символа");
            this.RuleFor(x => x.Surname)
                .NotEmpty()
                .WithMessage("Введите фамилию");
            this.RuleFor(x => x.Surname)
                .MinimumLength(3)
                .WithMessage("Минимальная длина фамилии - 3 символа");
            this.RuleFor(x => x.Login)
                .NotEmpty()
                .WithMessage("Введите логин");
            this.RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Введите пароль");
            this.RuleFor(x => x.MobilePhone)
                .NotNull()
                .WithMessage("Введите мобильный телефон")
                .Matches(new Regex(@"^\+[0-9]{11}$"))
                .WithMessage("Пожалуйста, введите корректный номер телефона (Формат: +12223334455)");
        }
    }
}
