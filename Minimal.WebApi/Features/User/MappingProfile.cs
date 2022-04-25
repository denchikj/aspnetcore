using AutoMapper;
using Minimal.WebApi.Features.User.DTO;
using Minimal.WebApi.Features.User.Entities;
using Minimal.WebApi.Features.User.Helpers;

namespace Minimal.WebApi.User;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<UserEntity, ReadUserDto>();
        CreateMap<RegisterUserDto, UserEntity>();
        CreateMap<TokenPair, TokenPairDto>();
    }
}
