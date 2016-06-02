
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.Site.Bindings;
using CollectedCompany.Services;

namespace CollectedCompany.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IWebsiteResources websiteResources) : base(websiteResources) { }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ConvertCards()
        {
            MtgJsonCardConverter.ConvertCards();

            return Json(new { success = true}, JsonRequestBehavior.AllowGet);
        }
    }
}