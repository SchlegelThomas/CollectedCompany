using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Areas.AdminPortal.ViewModels;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class ThemeController : AdminBaseController
    {

        public ThemeController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {
            
        }


        public ActionResult Index()
        {
            var model = AdminPortalResources.ApplicationResources.HtmlTemplates.FirstOrDefault(x => x.IsActive);


            return View(model);
        }

        public ActionResult Template()
        {
            return View();
        }

        public ActionResult Colors()
        {
            return View();
        }

        public PartialViewResult Preview()
        {
            return PartialView("_Preview");
        }

        public virtual PartialViewResult ColorPallete(string hexValue)
        {
            var toUpdate = AdminPortalResources.ApplicationResources.HtmlColors.FirstOrDefault(x => x.CssSelector == "UserTest");
            toUpdate.Value = hexValue;
            AdminPortalResources.ApplicationResources.SaveChanges();
            return PartialView("_ColorPallete");
        }

        public virtual PartialViewResult ColorPallettePrimary()
        {
            return PartialView("_ColorPallettePrimary");
        }

        public virtual PartialViewResult ColorPalleteSecondary()
        {
            return PartialView("_ColorPalletteSecondary");
        }

        public virtual PartialViewResult ColorPalleteTertiary()
        {
            return PartialView("_ColorPalletteTertiary");
        }
    }
}