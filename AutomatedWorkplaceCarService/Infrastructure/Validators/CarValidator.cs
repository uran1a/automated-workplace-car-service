using AutomatedWorkplaceCarService.BLL.DTOs.Car;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class CarValidator : AbstractValidator<CreateCarDTO>
    {
        public CarValidator()
        {
            this.RuleFor(x => x.YearOfRelease)
                .NotEmpty()
                .WithMessage("Введите год выпуска автомобиля")
                .GreaterThanOrEqualTo(1950)
                .WithMessage("Год выпуска не должен быть меньше 1950 года");
            this.RuleFor(x => x.EnginePower)
                .NotEmpty()
                .WithMessage("Введите мощность двигателя автомобиля")
                .GreaterThanOrEqualTo(60)
                .WithMessage("Мощность двигателя должена быть больше 60 л/с");
            this.RuleFor(x => x.BrandId)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Выберите бренд автомобиля");
            this.RuleFor(x => x.ModelId)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Выберите модель автомобиля");
            this.RuleFor(x => x.TransmissionId)
                .NotEmpty()
                .GreaterThanOrEqualTo(0)
                .WithMessage("Выберите тип трансмиссии автомобиля");
        }
    }
}
