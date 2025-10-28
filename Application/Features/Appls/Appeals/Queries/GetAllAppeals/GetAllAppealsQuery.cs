using Application.Features.Appls.Appeals.Dtos.GetAllAppeals;
using Application.Features.Appls.Appeals.Queries.GetAllAppeals.MapToAppeal;
using Application.Ports.Persistence.Repositories;
using Core.Application.Paginations.Models;
using MediatR;

namespace Application.Features.Appls.Appeals.Queries.GetAllAppeals;

public class GetAllAppealsQuery : PageRequest, IRequest<GetAllAppealsQueryResponse>
{
    public AppealFilter AppealFilter { get; set; }

    public GetAllAppealsQuery(
        int size,
        int index,
        AppealFilter appealFilter)
        : base(size, index)
    {
        AppealFilter = appealFilter;
    }
}

public class GetAllAppealsQueryHandler : IRequestHandler<GetAllAppealsQuery, GetAllAppealsQueryResponse>
{
    // private readonly InboxStrategyProvider _inboxStrategyProvider;
    // private readonly AppealRulesManager _appealRulesManager;
    private readonly IAppealRepository _appealRepository;

    public GetAllAppealsQueryHandler(IAppealRepository appealRepository)
    {
        _appealRepository = appealRepository;
    }

    public async Task<GetAllAppealsQueryResponse> Handle(GetAllAppealsQuery request,
        CancellationToken cancellationToken)
    {
        GetAllAppealsQueryResponse response = new();

        var appeals = _appealRepository.GetAll();

        var pageResponse = _appealRepository.GetQueryableAsPageResponse(appeals, request.Index, request.Size);
        response.Appeals = pageResponse.MapToAppeal();

        return response;
    }

    // private Expression<Func<Appeal, bool>> GeneratePredicateForActor(ActorTypeEnum actorType, int actorId,
    //     GetAllAppealsQuery request)
    // {
    //     var predicate = _inboxStrategyProvider.Provide(actorType).GeneratePredicate(actorId);
    //     predicate = predicate
    //         .And(a => request.AppealFilter.StatusId == null || a.StatusId == request.AppealFilter.StatusId)
    //         .And(a => string.IsNullOrEmpty(request.AppealFilter.Search)
    //                   || a.AuthorityName.ToLower().Contains(request.AppealFilter.Search.ToLower())
    //                   || a.PermitType.Name.ToLower().Contains(request.AppealFilter.Search.ToLower())
    //                   || a.PlateNumber.ToLower().Contains(request.AppealFilter.Search.ToLower())
    //                   || a.AppealActors.Any(x => x.Actor.ActorTypeId == ActorTypeEnum.Transporter.ToInt()
    //                                              && x.Actor.ActorTinDetail.CompanyName.ToLower()
    //                                                  .Contains(request.AppealFilter.Search.ToLower())))
    //         .And(a => string.IsNullOrEmpty(request.AppealFilter.PlateNumber) ||
    //                   a.PlateNumber.ToLower().Contains(request.AppealFilter.PlateNumber.ToLower()))
    //         .And(a => string.IsNullOrEmpty(request.AppealFilter.CompanyName) || a.AppealActors.Any(x =>
    //             x.Actor.ActorTypeId == ActorTypeEnum.Transporter.ToInt()
    //             && x.Actor.ActorTinDetail.CompanyName.ToLower()
    //                 .Contains(request.AppealFilter.CompanyName.ToLower())))
    //         .And(a => string.IsNullOrEmpty(request.AppealFilter.Tin) || a.AppealActors.Any(x =>
    //             x.Actor.ActorTypeId == ActorTypeEnum.Transporter.ToInt()
    //             && x.Actor.ActorTinDetail.Tin.Contains(request.AppealFilter.Tin)))
    //         .And(a => string.IsNullOrEmpty(request.AppealFilter.AuthorityCountry) || a.AuthorityCode.ToLower()
    //             .Contains(request.AppealFilter.AuthorityCountry.ToLower()))
    //         .And(a => request.AppealFilter.PermitTypeId == null ||
    //                   a.PermitTypeId == request.AppealFilter.PermitTypeId)
    //         .And(a => string.IsNullOrEmpty(request.AppealFilter.PermitNumber) || (a.PermitId != null &&
    //             a.PermitId.ToLower().Contains(request.AppealFilter.PermitNumber.ToLower())))
    //         .And(a => request.AppealFilter.AppealId == null || a.Id == request.AppealFilter.AppealId)
    //         .And(a => request.AppealFilter.StartDate == null || a.CreateDate.Date >=
    //             DateTime.SpecifyKind(request.AppealFilter.StartDate.Value.Date, DateTimeKind.Utc))
    //         .And(a => request.AppealFilter.EndDate == null || a.CreateDate.Date <=
    //             DateTime.SpecifyKind(request.AppealFilter.EndDate.Value.Date, DateTimeKind.Utc));
    //
    //     return PredicateBuilder.False<Appeal>().Or(predicate);
    // }
}