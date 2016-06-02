using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public partial class AdminSettingsController : AdminBaseController
    {
        public AdminSettingsController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }

        public virtual ActionResult General()
        {
            return View();
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

        public virtual ActionResult Notifications()
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