using AutoMapper;
using Minimal.WebApi.Helpers;

namespace Minimal.WebApi.User;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity, ReadUserDto>();
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<JwtTokenHelper.TokenPair, TokenPairDto>();
    }
}
