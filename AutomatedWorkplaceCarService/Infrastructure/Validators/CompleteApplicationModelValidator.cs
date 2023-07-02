using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class CompleteApplicationModelValidator : AbstractValidator<CompleteApplicationViewModel>
    {
        public CompleteApplicationModelValidator()
        {
            this.RuleFor(x => x.WorkshopAddress)
                 .NotEmpty()
                 .WithMessage("Введите адрес мастерской, откуда клиент сможет забрать автомобиль");
        }
    }
}
