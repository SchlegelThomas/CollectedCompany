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
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Customize()
        {

            return View();
        }

        public ActionResult Inventory()
        {
            return View();
        }

        public ActionResult Customers()
        {

            return View();
        }

        public ActionResult Reports()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        public ActionResult Categories()
        {
            return View();
        }

        

        public ActionResult Transfers()
        {
            return View();
        }

        


    }
}