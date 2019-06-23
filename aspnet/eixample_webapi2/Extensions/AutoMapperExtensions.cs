using Autofac;
using AutoMapper;
using eixample_webapi2.Miscellaneous;

namespace eixample_webapi2.Extensions
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