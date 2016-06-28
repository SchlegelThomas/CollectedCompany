using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
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
        public const string TempFolder = "/Temp";
        public const string MapTempFolder = "~" + TempFolder;

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

        public string GetTempSavedFilePath(HttpPostedFileBase file, string newFileName)
        {
            var serverPath = HttpContext.Server.MapPath(TempFolder);
            if (Directory.Exists(serverPath) == false)
            {
                Directory.CreateDirectory(serverPath);
            }

            var fileName = Path.GetFileName(newFileName);
            fileName = SaveTemporaryFileImage(file, serverPath, fileName);

            CleanUpTempFolder(1);
            return Path.Combine(TempFolder, fileName);
        }

        public void CleanUpTempFolder(int hoursOld)
        {
            try
            {
                var currentUtcNow = DateTime.UtcNow;
                var serverPath = HttpContext.Server.MapPath("/Temp");
                if (!Directory.Exists(serverPath)) return;
                var fileEntries = Directory.GetFiles(serverPath);

                foreach (var fileEntry in from fileEntry in fileEntries let fileCreationTime = System.IO.File.GetCreationTimeUtc(fileEntry) let res = currentUtcNow - fileCreationTime where res.TotalHours > hoursOld select fileEntry)
                {
                    System.IO.File.Delete(fileEntry);
                }
            }
            catch
            {
                // ignored
            }
        }

        public static string SaveTemporaryFileImage(HttpPostedFileBase file, string serverPath, string fileName)
        {
            var img = new WebImage(file.InputStream);

            var fullFileName = Path.Combine(serverPath, fileName);

            if (System.IO.File.Exists(fullFileName))
            {
                System.IO.File.Delete(fullFileName);
            }

            img.Save(fullFileName);
            return Path.GetFileName(img.FileName);
        }

    }
}