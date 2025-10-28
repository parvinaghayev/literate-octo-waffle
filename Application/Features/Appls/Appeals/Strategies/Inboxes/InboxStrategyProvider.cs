// using Application.Features.Appls.Appeals.Queries.Strategies.Inboxes.Strategies;
// using Application.Features.Appls.Appeals.Strategies.Inboxes;
// using Application.Features.Appls.Appeals.Strategies.Inboxes.Strategies;
// using AttributeInjection.Attributes.ForConretes;
// using Core.IoC;
// using Domain.Enums.Actors;
//
// namespace Application.Features.Appls.Appeals.Queries.Strategies.Inboxes
// {
//     [StandaloneScoped]
//     public class InboxStrategyProvider
//     {
//         private Dictionary<ActorTypeEnum, IInboxStrategy> config = new()
//         {
//             {ActorTypeEnum.Transporter,DIInjectionTool.GetService<TransporterInboxStrategy>()},
//             {ActorTypeEnum.Operator,DIInjectionTool.GetService<OperatorInboxStrategy>()},
//              {ActorTypeEnum.Administrator,DIInjectionTool.GetService<AdministratorInboxStrategy>()}
//         };
//         public IInboxStrategy Provide(ActorTypeEnum actorType)
//         {
//             return config[actorType];
//         }
//     }
// }
//

