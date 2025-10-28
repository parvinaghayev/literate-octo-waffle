using Application.Features.Appls.Appeals.Dtos.GetAppealById;
using Domain.Entities.Appls;

namespace Application.Features.Appls.Appeals.Queries.GetAppealById.MapToAppeal
{
    public static class MapToAppealExtension
    {
        public static AppealDetails MapToAppeal(Appeal appeal)
        {
            return new AppealDetails
            {
                Id = appeal.Id,
                Name = appeal.Name,
            };
        }


        // public static AppealRejectDetailDto MapToAppealRejectDetail(AppealRejectDetail appealRejectDetail)
        // {
        //     return new AppealRejectDetailDto
        //     {
        //         Description = appealRejectDetail.Description
        //     };
        // }
        //
        // public static AppealDetailDto MapToAppealDetail(Appeal appeal)
        // {
        //     return new AppealDetailDto
        //     {
        //         StartingCountry = appeal.StartingCountry.Name,
        //         AuthorityCountry = appeal.AuthorityName,
        //         DestinationCountry = appeal.DestinationCountry.Name,
        //         PermitType = appeal.PermitType.Name,
        //         PlateNumber = appeal.PlateNumber,
        //         TrailerNumber = appeal.TrailerNumber,
        //         Year = appeal.Year,
        //         StatusName = appeal.Status.Name
        //     };
        // }

        // public static List<AppealStatusLogDto> MapToStatusLogs(IEnumerable<AppealStatusLog> statusLogs, int actorTypeId)
        // {
        //     var dtos = new List<AppealStatusLogDto>();
        //
        //     statusLogs.ToList().ForEach(x => dtos.Add(new AppealStatusLogDto
        //     {
        //         Id = x.Id,
        //         StatusName = x.StatusName,
        //         StatusDescription = x.StatusDescription,
        //         ActorName = actorTypeId == ActorTypeEnum.Transporter.ToInt() ? null : x.Actor.Fullname,
        //         ActorPosition = actorTypeId == ActorTypeEnum.Transporter.ToInt() ? null : x.Actor.Position,
        //         CreateDate = x.CreateDate,
        //     }));
        //
        //     return dtos;
        // }
    }
}