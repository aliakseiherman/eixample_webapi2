using Autofac;
using EixampleDotnet.Entities;
using EixampleDotnet.EntityFramework;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace EixampleDotnet.Application.Extensions
{
    public static class AutofacExtensions
    {
        public static void RegisterServices(this ContainerBuilder builder)
        {
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager<ApplicationUser>>().InstancePerLifetimeScope();

            builder.RegisterType<AppDbContext>().InstancePerLifetimeScope();
            builder.RegisterType<Session>().InstancePerLifetimeScope();
            builder.RegisterType<TenantService>().As<ITenantService>().InstancePerLifetimeScope();
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerLifetimeScope();
            builder.RegisterType<TeamService>().As<ITeamService>().InstancePerLifetimeScope();
        }
    }
}
