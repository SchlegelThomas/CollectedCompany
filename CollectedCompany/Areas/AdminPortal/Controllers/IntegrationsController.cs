using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class IntegrationsController : AdminBaseController
    {
        public IntegrationsController(IAdminPortalResources adminResources) 
            : base(adminResources)
        {
            
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult GoogleMerchants()
        {
            return View();
        }

        public ActionResult TcgPlayer()
        {
            return View();
        }

        public ActionResult Amazon()
        {
            return View();
        }
        
        
    }
}