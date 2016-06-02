using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public partial class AdminBaseController : Controller
    {
        public IAdminPortalResources AdminPortalResources;

        public AdminBaseController(IAdminPortalResources adminPortalResources)
        {
            AdminPortalResources = adminPortalResources;
        }


        public virtual JsonResult JsonGetResponse(object dynamicJsonResponse)
        {
            return Json(dynamicJsonResponse, JsonRequestBehavior.AllowGet);
        }


    }
}