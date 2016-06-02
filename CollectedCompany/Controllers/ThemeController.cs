using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;

namespace CollectedCompany.Controllers
{
    public class SiteThemeController : BaseController
    {
        public SiteThemeController(IWebsiteResources websiteResources) : base(websiteResources) { }

        public ActionResult Theme()
        {
            var activeTheme = GetActiveTheme();

            return PartialView("_Theme", activeTheme);
        }
        
    }
}