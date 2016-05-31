using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class AdminSettingsController : AdminBaseController
    {
        public AdminSettingsController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }

        public ActionResult General()
        {
            return View();
        }

        public ActionResult Payments()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            return View();
        }

        public ActionResult Shipping()
        {
            return View();
        }

        public ActionResult Taxes()
        {
            return View();
        }

        public ActionResult Notifications()
        {
            return View();
        }

        public ActionResult Files()
        {
            return View();
        }

        public ActionResult Account()
        {
            return View();
        }



    }
}