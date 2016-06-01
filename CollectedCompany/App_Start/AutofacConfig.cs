using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using CollectedCompany.Models;
using CollectedCompany.Models.Application;
using CollectedCompany.Models.Shared;
using CollectedCompany.Plugins;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Impl;
using CollectedCompany.ServiceLayer.Integrations.Amazon.Bindings;
using CollectedCompany.ServiceLayer.Integrations.Amazon.Impl;
using dotless.Core;

namespace CollectedCompany.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes()
               .Where(t => t.Name.EndsWith("Service"))
               .AsImplementedInterfaces()
               .InstancePerRequest();

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            builder.RegisterType<ApplicationDbContext>().AsSelf();
            builder.RegisterType<SharedDbContext>().AsSelf();

            builder.RegisterType<AmazonProductAdvertisingService>().As<IAmazonProductAdvertisingService>();
            builder.RegisterType<AdminPortalResources>().As<IAdminPortalResources>();
            builder.RegisterModule<AutofacWebTypesModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            
        }
    }
}