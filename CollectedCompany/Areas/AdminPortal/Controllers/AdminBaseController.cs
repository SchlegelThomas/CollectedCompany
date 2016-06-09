using System.Web;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;
using Microsoft.AspNet.Identity.Owin;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class AdminBaseController : Controller
    {
        public IAdminPortalResources AdminPortalResources;
        private ApplicationUserManager _userManager;
        private ApplicationSignInManager _signInManager;

        public AdminBaseController(IAdminPortalResources adminPortalResources)
        {
            AdminPortalResources = adminPortalResources;
        }


        protected ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            set
            {
                _userManager = value;
            }
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }


        public virtual JsonResult JsonGetResponse(object dynamicJsonResponse)
        {
            return Json(dynamicJsonResponse, JsonRequestBehavior.AllowGet);
        }


    }
}