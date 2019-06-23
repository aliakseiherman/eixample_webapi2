using AutoMapper;
using eixample_webapi2.Dto;
using eixample_webapi2.Entities;

namespace eixample_webapi2.Miscellaneous
{
    public class AutoMapperWebApiBootstrap : Profile
    {
        public AutoMapperWebApiBootstrap()
        {
            CreateMap<TeamDto, Team>();
        }
    }
}