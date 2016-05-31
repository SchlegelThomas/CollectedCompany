using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class ThemeController : AdminBaseController
    {

        public ThemeController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }


        // GET: AdminPortal/Theme
        public ActionResult Index()
        {
            return View();
        }
    }
}