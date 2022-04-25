using AutoMapper;

namespace Minimal.WebApi.Meetup;

public class MeetupMappingProfile : Profile
{
    public MeetupMappingProfile()
    {
        CreateMap<MeetupEntity, ReadMeetupDto>();
        CreateMap<CreateMeetupDto, MeetupEntity>();
        CreateMap<UpdateMeetupDto, MeetupEntity>();
    }
}
