using AutomatedWorkplaceCarService.WEB.ViewModels;
using FluentValidation;

namespace AutomatedWorkplaceCarService.WEB.Infrastructure.Validators
{
    public class EvaluationApplicatonModelValidator : AbstractValidator<EvaluationApplicationViewModel>
    {
        public EvaluationApplicatonModelValidator()
        {
            this.RuleFor(x => x.StartWork)
                .NotEmpty()
                .WithMessage("Введите начало периода");
            this.RuleFor(x => x.EndWork)
                .NotEmpty()
                .WithMessage("Введите конец периода");
            this.RuleFor(x => x.Amount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Введите сумму");
        }
    }
}
