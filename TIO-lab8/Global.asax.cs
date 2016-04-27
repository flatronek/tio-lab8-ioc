using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TIO_lab8.DBInterfaces;
using TIO_lab8.LiteDbRepositories;
using TIO_lab8.Logger;
using TIO_lab8.SqlRepositories;

namespace TIO_lab8
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            initAutofacConfig();
        }

        private void initAutofacConfig()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<SqlPaintingsRepository>().As<IPaintingsRepository>().SingleInstance();
            builder.RegisterType<LiteDbAuthorsRepository>().As<IAuthorsRepository>().SingleInstance();

            builder.RegisterType<Logger.Logger>().As<Logger.ILogger>().SingleInstance();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var config = GlobalConfiguration.Configuration;

            config.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }
    }
}
