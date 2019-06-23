using Autofac;
using Autofac.Integration.WebApi;
using eixample_webapi2.Controllers;
using eixample_webapi2.Filters;

namespace eixample_webapi2.Extensions
{
    public static class AutofacExtensions
    {
        public static void RegisterWebApi(this ContainerBuilder builder)
        {
            builder.AddAutoMapper();

            builder.Register(x => new MultiTenancyFilter())
                .AsWebApiActionFilterOverrideFor<AccountController>()
                .InstancePerRequest()
                .PropertiesAutowired();

            builder.Register(x => new MultiTenancyFilter())
                .AsWebApiActionFilterOverrideFor<SessionController>()
                .InstancePerRequest()
                .PropertiesAutowired();

            builder.Register(x => new MultiTenancyFilter())
                .AsWebApiActionFilterOverrideFor<AuthController>()
                .InstancePerRequest()
                .PropertiesAutowired();

            builder.Register(x => new MultiTenancyFilter())
                .AsWebApiActionFilterOverrideFor<TeamController>()
                .InstancePerRequest()
                .PropertiesAutowired();
            
            builder.RegisterType<AccountController>().InstancePerLifetimeScope();
            builder.RegisterType<SessionController>().InstancePerLifetimeScope();
            builder.RegisterType<TeamController>().InstancePerLifetimeScope();
            builder.RegisterType<AuthController>().InstancePerLifetimeScope();
            builder.RegisterType<TeamController>().InstancePerLifetimeScope();
        }
    }
}