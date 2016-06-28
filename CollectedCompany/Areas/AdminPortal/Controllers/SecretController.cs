using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class SecretController : AdminBaseController
    {
        public SecretController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {

        }

        public ActionResult ThemeImageUploader()
        {
            return View();
        }


        [HttpPost]
        public JsonResult UploadThemePicture(HttpPostedFileBase file, string themeName)
        {
            if (file != null)
            {

                var webPath = GetTempSavedFilePath(file, file.FileName).Replace("/", "\\");
                var imageLookup = new WebImage(Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(webPath)));

                String azureImageUrl = AdminPortalResources.ImageStorageService.SaveImage(new FileStream(imageLookup.FileName, FileMode.Open), imageLookup.FileName, "theme");

                var theme = AdminPortalResources.SharedResources.HtmlTemplates.FirstOrDefault(x => x.Name == themeName);
                var localTheme = AdminPortalResources.ApplicationResources.HtmlTemplates.FirstOrDefault(x => x.Name == themeName);

                if (theme != null)
                    theme.ImageUrl = azureImageUrl;

                if (localTheme != null)
                    localTheme.ImageUrl = azureImageUrl;

                AdminPortalResources.SharedResources.SaveChanges();
                AdminPortalResources.ApplicationResources.SaveChanges();

                return Json(new { Success = true });
            }

            return Json(new { Success = false });
        }



    }
}