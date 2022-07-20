using FluentValidation;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;

namespace N_TierArchitectureToDoApp.Service.ValidationRules.FluentValidation
{
    public class WorksAddRequestValidator : AbstractValidator<WorksAddRequest>
    {
        public WorksAddRequestValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş geçilemez");
        }
    }
}
