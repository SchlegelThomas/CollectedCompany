using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CollectedCompany.Plugins;
using dotless.Core.configuration;
using dotless.Core.Plugins;

namespace CollectedCompany.App_Start
{
    public static class DotLessConfig
    {
        public static void Configure()
        {
            DotlessConfiguration config = new DotlessConfiguration();

            config.Plugins.Add(new GenericPluginConfigurator<UserProfilePlugin>());
            config.Plugins.Add(new GenericPluginConfigurator<UserFontPlugin>());
        }
    }
}