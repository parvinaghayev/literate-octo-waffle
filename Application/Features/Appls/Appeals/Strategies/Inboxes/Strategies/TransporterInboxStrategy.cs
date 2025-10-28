// using AttributeInjection.Attributes.ForConretes;
// using Core.Application.Extensions;
// using Core.Security.Jwt.Helpers;
// using Domain.Entities.Appls;
// using Domain.Enums.Actors;
// using System.Linq.Expressions;
// using Application.Features.Appls.Appeals.Strategies.Inboxes;
//
// namespace Application.Features.Appls.Appeals.Queries.Strategies.Inboxes.Strategies
// {
//     [StandaloneScoped]
//
//     internal class TransporterInboxStrategy : IInboxStrategy
//     {
//         private readonly ITokenHelper _tokenHelper;
//
//         public TransporterInboxStrategy(ITokenHelper tokenHelper)
//         {
//             _tokenHelper = tokenHelper;
//         }
//         public Expression<Func<Appeal, bool>> GeneratePredicate(int actorId)
//         {
//             int userProfileId = _tokenHelper.GetUserProfileId();
//
//             Expression<Func<Appeal, bool>> predicate =
//                     PredicateBuilder.New<Appeal>(true)
//                     .And(a => a.AppealActors.Any(x=> x.Actor.UserProfileId == userProfileId))
//                     .And(a => InboxStatics.TransporterAccepted.Contains(a.StatusId));
//
//             return predicate;
//         }
//     }
// }

