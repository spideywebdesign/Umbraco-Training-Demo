using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using CoreProject.Events;
using System.Web.Http;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Web;

namespace CoreProject.Helpers
{
    public class IocHelper
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(ApplicationContext.Current).AsSelf();

            // register all controllers found in your assembly
            builder.RegisterControllers(typeof(UmbracoEvents).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoEvents).Assembly);


            // register Umbraco MVC + web API controllers used by the admin site
            builder.RegisterControllers(typeof(UmbracoApplication).Assembly);
            builder.RegisterApiControllers(typeof(UmbracoApplication).Assembly);

            //builder.RegisterApiControllers(typeof(Umbraco.Forms.Web.Trees.FormTreeController).Assembly);
            builder.RegisterApiControllers(typeof(Terratype.Controllers.AjaxController).Assembly);

            //Fetch all services from assembly based on naming convention "EndsWith" Service or Strategy
            builder.RegisterAssemblyTypes(typeof(UmbracoEvents).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            //builder.RegisterType<RobotsService>().As<IRobotsService>().SingleInstance();
            //builder.RegisterType<AutoNodeGeneratorService>().As<IAutoNodeGeneratorService>().SingleInstance();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}