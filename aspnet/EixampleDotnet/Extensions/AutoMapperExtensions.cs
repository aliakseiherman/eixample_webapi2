using Autofac;
using AutoMapper;
using EixampleDotnet.Miscellaneous;

namespace EixampleDotnet.Extensions
{
    public static class AutoMapperExtensions
    {
        public static void AddAutoMapper(this ContainerBuilder builder)
        {
            var automapperConfig = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperWebApiBootstrap()));
            var mapper = automapperConfig.CreateMapper();
            builder.Register(c => mapper).As<IMapper>().SingleInstance();
        }
    }
}