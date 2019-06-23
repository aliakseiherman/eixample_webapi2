using Autofac;
using Autofac.Integration.WebApi;
using eixample_webapi2.Application.Extensions;
using eixample_webapi2.Extensions;
using System.Reflection;
using System.Web.Http;

namespace eixample_webapi2
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var builder = new ContainerBuilder();
            
            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(GlobalConfiguration.Configuration);

            // OPTIONAL: Register the Autofac model binder provider.
            builder.RegisterWebApiModelBinderProvider();

            builder.RegisterServices();

            builder.RegisterWebApi();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
