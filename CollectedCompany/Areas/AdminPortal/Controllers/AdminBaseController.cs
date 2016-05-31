using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class AdminBaseController : Controller
    {
        public IAdminPortalResources AdminPortalResources;

        public AdminBaseController(IAdminPortalResources adminPortalResources)
        {
            AdminPortalResources = adminPortalResources;
        }


        public JsonResult JsonGetResponse(object dynamicJsonResponse)
        {
            return Json(dynamicJsonResponse, JsonRequestBehavior.AllowGet);
        }


    }
}