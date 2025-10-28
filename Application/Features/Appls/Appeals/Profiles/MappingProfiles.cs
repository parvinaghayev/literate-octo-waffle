using Application.Features.Appls.Appeals.Requests.CreateAppeal;
using AutoMapper;
using Domain.Entities.Appls;

namespace Application.Features.Appls.Appeals.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateAppealRequest, Appeal>();
        }
    }
}