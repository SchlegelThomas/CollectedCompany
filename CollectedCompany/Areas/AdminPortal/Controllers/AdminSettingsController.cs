using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class AdminSettingsController : AdminBaseController
    {
        public AdminSettingsController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }

        public virtual ActionResult General()
        {
            Settings settings = AdminPortalResources.ApplicationResources.Settings.FirstOrDefault() ?? new Settings();

            return View(settings);
        }

        public virtual ActionResult Payments()
        {
            return View();
        }

        public virtual ActionResult Checkout()
        {
            return View();
        }

        public virtual ActionResult Shipping()
        {
            return View();
        }

        public virtual ActionResult Taxes()
        {
            return View();
        }

        public virtual ActionResult Files()
        {
            return View();
        }

        public virtual ActionResult Account()
        {
            return View();
        }



    }
}