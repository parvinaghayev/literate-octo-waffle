using Application.Features.Appls.Appeals.RuleManagers;
using Application.Features.Appls.Appeals.RuleManagers.Statics;
using Application.Ports.Persistence.Repositories;
using Core.CrossCuttingConcerns.Exceptions.Types;
using MediatR;

namespace Application.Features.Appls.Appeals.Queries.GetAppealById
{
    public class GetAppealByIdQuery : IRequest<GetAppealByIdQueryResponse>
    {
        public int Id { get; set; }

        public GetAppealByIdQuery(
            int id)
        {
            Id = id;
        }

        public class GetAppealByIdQueryHandler : IRequestHandler<GetAppealByIdQuery, GetAppealByIdQueryResponse>
        {
            private readonly AppealRulesManager _appealRulesManager;
            private readonly IAppealRepository _appealRepository;

            public GetAppealByIdQueryHandler(AppealRulesManager appealRulesManager, IAppealRepository appealRepository)
            {
                _appealRulesManager = appealRulesManager;
                _appealRepository = appealRepository;
            }

            public async Task<GetAppealByIdQueryResponse> Handle(GetAppealByIdQuery request,
                CancellationToken cancellationToken)
            {
                var response = new GetAppealByIdQueryResponse();
                var appeal = await _appealRepository.GetByIdAsync(request.Id)
                             ?? throw new NotFoundException(string.Format(
                                 AppealExceptionMessages.DoesAppealExistsWithGivenIdErrorMessage, request.Id));

                response.Appeal = MapToAppeal.MapToAppealExtension.MapToAppeal(appeal);
                return response;
            }
        }
    }
}