using AutoMapper;
using CMS.Application.Dtos.Users;
using CMS.Domain.Models.Users;

namespace CMS.Application.AutoMapper.Users;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegisterDto, ApplicationUser>();
    }
}
