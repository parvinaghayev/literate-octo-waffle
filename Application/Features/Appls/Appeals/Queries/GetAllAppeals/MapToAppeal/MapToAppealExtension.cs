using Application.Features.Appls.Appeals.Dtos.GetAllAppeals;
using Core.Application.Paginations.Models;
using Domain.Entities.Appls;

namespace Application.Features.Appls.Appeals.Queries.GetAllAppeals.MapToAppeal
{
    public static class MapToAppealExtension
    {
        public static PageResponse<AppealDto> MapToAppeal(this PageResponse<Appeal> pageResponse)
        {
            return new PageResponse<AppealDto>
            {
                Size = pageResponse.Size,
                Index = pageResponse.Index,
                Total = pageResponse.Total,
                HasNext = pageResponse.HasNext,
                HasPrev = pageResponse.HasPrev,
                PageCount = pageResponse.PageCount,
                Data = pageResponse
                    .Data
                    .Select(MapToGetAllAppealDto)
                    .ToList(),
            };
        }

        public static AppealDto MapToGetAllAppealDto(Appeal appeal)
        {
            return new AppealDto
            {
                Id = appeal.Id,
                Name = appeal.Name
            };
        }
    }
}