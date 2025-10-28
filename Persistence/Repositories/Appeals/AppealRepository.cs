using Core.Persistence.Repositories;
using Domain.Entities.Appls;
using Persistence.Contexts;
using Application.Ports.Persistence.Repositories;

namespace Persistence.Repositories.Appeals
{
    public class AppealRepository : BaseRepository<Appeal, DatabaseContext>, IAppealRepository
    {
        public AppealRepository(DatabaseContext context) : base(context)
        {
        }
    }
}