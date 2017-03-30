using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using developer_stats_reporter.Controllers;
using developer_stats_reporter.Models.Operations;

namespace developer_stats_reporter
{
    public class IocConfigure
    {
        public static void ConfigureDependencyInjection()
        {
            var builder = new ContainerBuilder();

            //HomeController
            builder.RegisterType<HomeController>().InstancePerRequest();

            //StatOperations
            builder.RegisterType<StatOperations>().As<IStatOperations>().InstancePerDependency();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}