// using Application.Features.Appls.Appeals.Queries.Strategies.Inboxes;
// using AttributeInjection.Attributes.ForConretes;
// using Core.Application.Extensions;
// using Domain.Entities.Appls;
// using System.Linq.Expressions;
//
// namespace Application.Features.Appls.Appeals.Strategies.Inboxes.Strategies
// {
//     [StandaloneScoped]
//
//     public class AdministratorInboxStrategy : IInboxStrategy
//     {
//         public Expression<Func<Appeal, bool>> GeneratePredicate(int actorId)
//         {
//             Expression<Func<Appeal, bool>> predicate =
//                 PredicateBuilder.New<Appeal>(true)
//                 .And(a => InboxStatics.AdministratorAccepted.Contains(a.StatusId));
//
//             return predicate;
//         }
//     }
// }

