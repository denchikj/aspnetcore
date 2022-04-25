using AutoMapper;
using Minimal.WebApi.Features.Meetup.DTO;
using Minimal.WebApi.Features.Meetup.Entities;

namespace Minimal.WebApi.Meetup;

public class MeetupMappingProfile : Profile
{
    public MeetupMappingProfile()
    {
        CreateMap<MeetupEntity, ReadMeetupDto>()
            .ForMember(readDto => readDto.SignedUp, config => config.MapFrom(meetup => meetup.SignedUpUsers!.Count));
        CreateMap<CreateMeetupDto, MeetupEntity>();
        CreateMap<UpdateMeetupDto, MeetupEntity>();
    }
}
