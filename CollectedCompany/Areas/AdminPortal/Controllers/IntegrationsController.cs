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

        public virtual ActionResult Dashboard()
        {
            return View();
        }

        public virtual ActionResult GoogleMerchants()
        {
            return View();
        }

        public virtual ActionResult TcgPlayer()
        {
            return View();
        }

        public virtual ActionResult Amazon()
        {
            return View();
        }
        
        
    }
}