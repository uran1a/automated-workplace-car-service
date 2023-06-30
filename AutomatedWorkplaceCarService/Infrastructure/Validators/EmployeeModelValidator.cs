using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class EmployeeModelValidator : AbstractValidator<EmployeeViewModel>
    {
        public EmployeeModelValidator()
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
            this.RuleFor(x => x.PostId)
                .GreaterThan(0)
                .WithMessage("Выберите должность сотрудника");
        }
    }
}
