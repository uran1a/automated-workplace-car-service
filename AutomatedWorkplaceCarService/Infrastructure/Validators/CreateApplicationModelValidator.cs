using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class CreateApplicationModelValidator : AbstractValidator<CreateApplicationViewModel>
    {
        public CreateApplicationModelValidator() 
        {
            this.RuleFor(x => x.Descriptions)
                .NotEmpty()
                .WithMessage("Подробнее опишите услуги, которую требуется оказать автомобилю");
            this.RuleFor(x => x.CarId)
                .NotEmpty()
                .WithMessage("Выберите автомобиль, которому трубуется оказать услугу");
            this.RuleFor(x => x.ServiceId)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Выберите услугу, которую требуется оказать автомобилю");
            this.RuleFor(x => x.EmployeeId)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Выберите мастера, которую ходите доверить оказание услуги");
        }
    }
}
