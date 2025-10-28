// using AttributeInjection.Attributes.ForConretes;
// using Core.Application.Extensions;
// using Domain.Entities.Appls;
// using System.Linq.Expressions;
// using Application.Features.Appls.Appeals.Strategies.Inboxes;
//
// namespace Application.Features.Appls.Appeals.Queries.Strategies.Inboxes.Strategies
// {
//     [StandaloneScoped]
//
//     public class OperatorInboxStrategy : IInboxStrategy
//     {
//         public Expression<Func<Appeal, bool>> GeneratePredicate(int actorId)
//         {
//             Expression<Func<Appeal, bool>> predicate =
//                 PredicateBuilder.New<Appeal>(true)
//                 .And(a => InboxStatics.OperatorAccepted.Contains(a.StatusId));
//
//             return predicate;
//         }
//     }
// }

