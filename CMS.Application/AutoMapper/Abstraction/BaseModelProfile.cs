using AutoMapper;
using CMS.Application.Dtos.Abstraction;
using CMS.Domain.Models.Abstraction;

namespace CMS.Application.AutoMapper.Abstraction;

public class BaseModelProfile : Profile
{
    public BaseModelProfile()
    {
        CreateMap<BaseModel, BaseModelDto>().ReverseMap();
    }
}
