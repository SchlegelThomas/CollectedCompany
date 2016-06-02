using System;
using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;

namespace CollectedCompany.Controllers
{
    public class BaseController : Controller
    {
        public IWebsiteResources WebsiteResources;

        public BaseController(IWebsiteResources websiteResources)
        {
            WebsiteResources = websiteResources;
        }

        //We will Cache this stuff on app start
        public HtmlTemplate GetActiveTheme()
        {
            var activeTheme = WebsiteResources.ApplicationResources.HtmlTemplates.FirstOrDefault(x => x.IsActive);


            return activeTheme;
        }

        public String ActiveThemeUrl()
        {
            var activeThemeUrl = WebsiteResources.ApplicationResources.HtmlTemplates.FirstOrDefault(x => x.IsActive).TemplateUrl;

            return activeThemeUrl;
        }

    }
}