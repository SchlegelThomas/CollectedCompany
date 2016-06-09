using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{

    public class AdminController : AdminBaseController
    {
        public AdminController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }

        // GET: Admin
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Customize()
        {

            return View();
        }

        public virtual ActionResult Inventory()
        {
            return View();
        }

        public virtual ActionResult Customers()
        {

            return View();
        }

        public virtual ActionResult Reports()
        {
            return View();
        }

        public virtual ActionResult Dashboard()
        {
            return View();
        }

        public virtual ActionResult Categories()
        {
            return View();
        }



        public virtual ActionResult Transfers()
        {
            return View();
        }

        


    }
}