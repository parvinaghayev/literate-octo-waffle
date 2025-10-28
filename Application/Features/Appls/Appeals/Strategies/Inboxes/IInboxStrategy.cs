using System.Linq.Expressions;
using Domain.Entities.Appls;

namespace Application.Features.Appls.Appeals.Strategies.Inboxes
{
    public interface IInboxStrategy
    {
        Expression<Func<Appeal, bool>> GeneratePredicate(int actorId);
    }
}