using Application.Features.Appls.Appeals.RuleManagers.Statics;
using AttributeInjection.Attributes.ForConretes;
using Domain.Entities.Appls;
using Core.CrossCuttingConcerns.Exceptions.Types;

namespace Application.Features.Appls.Appeals.RuleManagers
{
    [StandaloneScoped]
    public class AppealRulesManager
    {
        public AppealRulesManager()
        {
        }

        public AppealRulesManager IsAppealEditableOrDeletable(Appeal appeal)
        {
            if (false) //For business rules
                throw new BusinessException(AppealExceptionMessages.IsAppealEditableOrDeletableErrorMessage);

            return this;
        }
    }
}