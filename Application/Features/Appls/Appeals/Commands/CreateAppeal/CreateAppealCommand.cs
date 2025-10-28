using Application.Features.Appls.Appeals.Requests.CreateAppeal;
using Application.Features.Appls.Appeals.RuleManagers;
using Application.Ports.Persistence.Repositories;
using AutoMapper;
using Domain.Entities.Appls;
using MediatR;

namespace Application.Features.Appls.Appeals.Commands.CreateAppeal;

public record CreateAppealCommand(CreateAppealRequest CreateAppealRequest) : IRequest<CreateAppealCommandResponse>;

public class CreateAppealHandler : IRequestHandler<CreateAppealCommand, CreateAppealCommandResponse>
{
    private readonly IMapper _mapper;
    private readonly IAppealRepository _appealRepository;
    private readonly AppealRulesManager _appealRulesManager;

    public CreateAppealHandler(AppealRulesManager appealRulesManager, IMapper mapper,
        IAppealRepository appealRepository)
    {
        _appealRulesManager = appealRulesManager;
        _mapper = mapper;
        _appealRepository = appealRepository;
    }

    public async Task<CreateAppealCommandResponse> Handle(CreateAppealCommand command,
        CancellationToken cancellationToken)
    {
        var appeal = _mapper.Map<Appeal>(command.CreateAppealRequest);
        await _appealRepository.AddAsync(appeal);
        await _appealRepository.SaveChangesAsync();

        return new CreateAppealCommandResponse { Id = appeal.Id };
    }
}