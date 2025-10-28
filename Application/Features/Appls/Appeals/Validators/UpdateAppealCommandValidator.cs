using Application.Features.Appls.Appeals.Commands.UpdateAppeal;
using FluentValidation;

namespace Application.Features.Appls.Appeals.Validators
{
    public class UpdateAppealCommandValidator : AbstractValidator<UpdateAppealCommand>
    {
        public UpdateAppealCommandValidator()
        {
            RuleFor(x => x.UpdateAppealRequest)
                .NotNull()
                .WithMessage("Appeal Update Dto cannot be null");
            // .SetValidator(new AppealUpdateDtoValidator())
        }
    }
}