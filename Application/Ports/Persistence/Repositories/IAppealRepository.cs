using AttributeInjection.Attributes.ForAbstracts;
using Core.Application.Ports.Repositories;
using Domain.Entities.Appls;

namespace Application.Ports.Persistence.Repositories;

[Repository]
public interface IAppealRepository : IRepository<Appeal>
{
}