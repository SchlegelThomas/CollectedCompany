using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public partial class ThemeController : AdminBaseController
    {

        public ThemeController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }


        // GET: AdminPortal/Theme
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual PartialViewResult ColorPallete(string hexValue)
        {
            var toUpdate = AdminPortalResources.ApplicationResources.HtmlColors.FirstOrDefault(x => x.CssSelector == "UserTest");
            toUpdate.Value = hexValue;
            AdminPortalResources.ApplicationResources.SaveChanges();
            return PartialView("_ColorPallete");
        }
    }
}