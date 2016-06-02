using System;
using System.Linq;
using CollectedCompany.Models;
using WebGrease.Css.Extensions;

namespace CollectedCompany.App_Start
{
    public static class AutomapperConfig
    {
        public static void Register()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(x => x.FullName.Contains("Collected")).ToList();


            assemblies.ForEach(assembly =>
            {
                assembly
                    .GetTypes()
                    .Where(type => typeof(IAutoMapConfig).IsAssignableFrom(type) && !type.IsAbstract && !type.IsInterface)
                    .ForEach(x =>
                    {
                        IAutoMapConfig mappingClass = (IAutoMapConfig)Activator.CreateInstance(x);

                        mappingClass.CreateMaps();
                    });

            });
        }
    }
}