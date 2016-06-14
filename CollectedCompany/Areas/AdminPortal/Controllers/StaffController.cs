using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public JsonResult EditStaff(string id)
        {
            var staff = AdminPortalResources.ApplicationResources.StaffMembers.FirstOrDefault(x => x.UserAccount.Id == id);

            return staff != null ? JsonGetResponse(new { Success = true, Data = staff }) : JsonGetResponse(new { Success = false });
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

        [HttpPost]
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

            if (!result.Succeeded)
                return Json(new { Success = false, Errors = result.Errors }, JsonRequestBehavior.AllowGet);

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

        [HttpPost]
        public JsonResult SaveStaff(string firstName, string lastName, string email, string userId)
        {
            var staff = AdminPortalResources.ApplicationResources.StaffMembers.FirstOrDefault(x => x.UserAccount.Id == userId);

            if (staff != null)
            {
                staff.UserAccount.FirstName = firstName;
                staff.UserAccount.LastName = lastName;
                staff.UserAccount.Email = email;
                AdminPortalResources.ApplicationResources.Entry(staff).State = EntityState.Modified;
                AdminPortalResources.ApplicationResources.SaveChanges();
                return Json(new { Success = true });
            }

            return Json(new { Success = false, Errors = "Could not locate staff" });
        }

        [HttpPost]
        public JsonResult DeleteStaff(string userId)
        {
            var staff = AdminPortalResources.ApplicationResources.StaffMembers.FirstOrDefault(x => x.UserAccount.Id == userId);

            if (staff != null)
            {
                AdminPortalResources.ApplicationResources.StaffMembers.Remove(staff);
                AdminPortalResources.ApplicationResources.SaveChanges();
                return Json(new { Success = true });
            }

            return Json(new { Success = false, Errors = "Could not locate staff" });
        }

        [HttpPost]
        public JsonResult UpdateRole(string role, string id, bool active)
        {
            var staff = AdminPortalResources.ApplicationResources.StaffMembers.FirstOrDefault(x => x.UserAccount.Id == id);

            if (staff != null)
            {
                AdminPortalResources.UserManagementService.UpdateRoles(new Permissions
                {
                    User = staff.UserAccount,
                    StaffRoles = new List<StaffPermission>
                    {
                        new StaffPermission
                        {
                            IsInRole = active,
                            UserRole = (StaffRoles) Enum.Parse(typeof(StaffRoles), role, true)
                        }
                    },
                    UserRoles = new List<UserPermission>()
                });

                return Json(new { Success = true });
            }

            return Json(new { Success = false });
        }
    }
}