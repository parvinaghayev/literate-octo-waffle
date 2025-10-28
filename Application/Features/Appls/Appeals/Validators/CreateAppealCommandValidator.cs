using Application.Features.Appls.Appeals.Commands.CreateAppeal;
using FluentValidation;

namespace Application.Features.Appls.Appeals.Validators
{
    public class CreateAppealCommandValidator : AbstractValidator<CreateAppealCommand>
    {
        public CreateAppealCommandValidator()
        {
            RuleFor(x => x.CreateAppealRequest)
                .NotNull()
                .WithMessage("Appeal Create Dto cannot be null");
            // .SetValidator(new AppealCreateDtoValidator())
        }
    }
}