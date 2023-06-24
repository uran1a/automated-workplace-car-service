using AutomatedWorkplaceCarService.WEB.Models;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class ClientModelValidator : AbstractValidator<ClientModel>
    {
        public ClientModelValidator()
        {
            this.RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Введите имя");
            this.RuleFor(x => x.Name)
                .MinimumLength(3)
                .WithMessage("Минимальная длина имени - 3 символа");
        }
    }
}
