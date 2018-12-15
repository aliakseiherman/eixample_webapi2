using AutoMapper;
using EixampleDotnet.Dto;
using EixampleDotnet.Entities;

namespace EixampleDotnet.Miscellaneous
{
    public class AutoMapperWebApiBootstrap : Profile
    {
        public AutoMapperWebApiBootstrap()
        {
            CreateMap<TeamDto, Team>();
        }
    }
}