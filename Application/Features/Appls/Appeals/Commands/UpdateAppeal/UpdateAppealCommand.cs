using Application.Features.Appls.Appeals.Requests.UpdateAppeal;
using Application.Features.Appls.Appeals.RuleManagers;
using Application.Features.Appls.Appeals.RuleManagers.Statics;
using Application.Ports.Persistence.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;

namespace Application.Features.Appls.Appeals.Commands.UpdateAppeal;

public record UpdateAppealCommand(int Id, UpdateAppealRequest UpdateAppealRequest) : IRequest<UpdateAppealCommandResponse>;

public class UpdateAppealHandler : IRequestHandler<UpdateAppealCommand, UpdateAppealCommandResponse>
{
    private readonly IAppealRepository _appealRepository;
    private readonly AppealRulesManager _appealRulesManager;

    public UpdateAppealHandler(IAppealRepository appealRepository, AppealRulesManager appealRulesManager)
    {
        _appealRepository = appealRepository;
        _appealRulesManager = appealRulesManager;
    }

    public async Task<UpdateAppealCommandResponse> Handle(UpdateAppealCommand command,
        CancellationToken cancellationToken)
    {
        var appeal = await _appealRepository.GetByIdAsync(command.Id)
                     ?? throw new NotFoundException(
                         string.Format(AppealExceptionMessages.DoesAppealExistsWithGivenIdErrorMessage,
                             command.Id));

        appeal.Name = command.UpdateAppealRequest.Name;

        _appealRulesManager.IsAppealEditableOrDeletable(appeal);

        await _appealRepository.UpdateAsync(appeal);
        await _appealRepository.SaveChangesAsync();

        return new UpdateAppealCommandResponse();
    }
}