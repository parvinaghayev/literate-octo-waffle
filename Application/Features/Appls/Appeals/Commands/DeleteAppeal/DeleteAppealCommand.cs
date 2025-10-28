using Application.Features.Appls.Appeals.RuleManagers;
using Application.Features.Appls.Appeals.RuleManagers.Statics;
using Application.Ports.Persistence.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;

namespace Application.Features.Appls.Appeals.Commands.DeleteAppeal;

public record DeleteAppealCommand(int id) : IRequest<DeleteAppealCommandResponse>;

public class DeleteAppealHandler : IRequestHandler<DeleteAppealCommand, DeleteAppealCommandResponse>
{
    private readonly IAppealRepository _appealRepository;
    private readonly AppealRulesManager _appealRulesManager;

    public DeleteAppealHandler(IAppealRepository appealRepository, AppealRulesManager appealRulesManager)
    {
        _appealRepository = appealRepository;
        _appealRulesManager = appealRulesManager;
    }

    public async Task<DeleteAppealCommandResponse> Handle(DeleteAppealCommand request,
        CancellationToken cancellationToken)
    {
        var appeal = await _appealRepository.GetByIdAsync(request.id)
                     ?? throw new NotFoundException
                         (string.Format(AppealExceptionMessages.DoesAppealExistsWithGivenIdErrorMessage, request.id));

        _appealRulesManager.IsAppealEditableOrDeletable(appeal);
        appeal.Deleted = true;

        await _appealRepository.UpdateAsync(appeal);
        await _appealRepository.SaveChangesAsync();

        return new DeleteAppealCommandResponse();
    }
}