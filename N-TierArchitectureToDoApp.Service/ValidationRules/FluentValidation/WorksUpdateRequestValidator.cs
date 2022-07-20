using FluentValidation;
using N_TierArchitectureToDoApp.Service.WorksServices.Dtos.RequestDtos;

namespace N_TierArchitectureToDoApp.Service.ValidationRules.FluentValidation
{
    public class WorksUpdateRequestValidator : AbstractValidator<WorksUpdateRequest>
    {
        public WorksUpdateRequestValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Update Açıklama boş geçilemez");

            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
