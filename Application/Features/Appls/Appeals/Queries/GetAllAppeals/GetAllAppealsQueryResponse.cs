using Application.Features.Appls.Appeals.Dtos.GetAllAppeals;
using Core.Application.Paginations.Models;

namespace Application.Features.Appls.Appeals.Queries.GetAllAppeals
{
    public class GetAllAppealsQueryResponse
    {
        public PageResponse<AppealDto> Appeals { get; set; }
    }
}