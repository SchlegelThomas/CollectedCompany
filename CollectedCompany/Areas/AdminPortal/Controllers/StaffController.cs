using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollectedCompany.Models;
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;
using CollectedCompany.ServiceLayer.Integrations.Site.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class StaffController : AdminBaseController
    {
        public StaffController(IAdminPortalResources adminPortalResources) : base(adminPortalResources) { }


        public virtual ActionResult Staff()
        {
            var staff = AdminPortalResources.ApplicationResources.StaffMembers.ToList();

            List<Permissions> permissions = new List<Permissions>();

            staff.ForEach(x =>
            {
                permissions.Add(AdminPortalResources.UserManagementService.GetPermission(x.UserAccount));
            });

            return View(permissions);
        }

        public PartialViewResult EditStaff(int staffId)
        {

            return PartialView();
        }

        public PartialViewResult StaffList()
        {
            var staff = AdminPortalResources.ApplicationResources.StaffMembers.ToList();

            List<Permissions> permissions = new List<Permissions>();

            staff.ForEach(x =>
            {
                permissions.Add(AdminPortalResources.UserManagementService.GetPermission(x.UserAccount));
            });

            return PartialView("_StaffList", permissions);
        }

        public JsonResult AddStaff(string firstName, string lastName, string email, string tempPassword)
        {
            var user = new ApplicationUser
            {
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                UserName = email,
                DciNumber = "8110758114"
            };

            var result = UserManager.Create(user, tempPassword);
            if (result.Succeeded)
            {
                UserManager.AddToRole(user.Id, UserRoles.Staff.ToString());
                var newUser = AdminPortalResources.ApplicationResources.Users.FirstOrDefault(x => x.Email == email);
                AdminPortalResources.ApplicationResources.StaffMembers.Add(new Staff
                {
                    UserAccount = newUser
                });

                AdminPortalResources.ApplicationResources.SaveChanges();
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                // Send an email with this link
                // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                // await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                return Json(new { Success = true }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = false, Errors = result.Errors }, JsonRequestBehavior.AllowGet);

        }
    }
}