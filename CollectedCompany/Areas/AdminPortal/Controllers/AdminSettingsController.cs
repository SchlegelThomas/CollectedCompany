using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Application;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class AdminSettingsController : AdminBaseController
    {
        public AdminSettingsController(IAdminPortalResources adminPortalResources)
            : base(adminPortalResources)
        {

        }

        public virtual ActionResult General()
        {
            Settings settings = AdminPortalResources.ApplicationResources.Settings.FirstOrDefault() ?? new Settings();

            if (settings.Id == Guid.Empty)
                AdminPortalResources.ApplicationResources.Settings.Add(settings);

            AdminPortalResources.ApplicationResources.SaveChanges();
            

            return View(settings);
        }

        public PartialViewResult StoreFront()
        {
            var settings = AdminPortalResources.ApplicationResources.Settings.FirstOrDefault() ?? new Settings();

            var lookupStoreFront = settings.StoreFront ?? new StoreFront
            {
                BusinessName = "Your Business Name"
            };

            return PartialView("_Storefront", lookupStoreFront);
        }

        [HttpPost]
        public JsonResult SaveStorefrontSettings(StoreFront storeFront, Guid settingsId)
        {
            var settings = AdminPortalResources.ApplicationResources.Settings.FirstOrDefault(x => x.Id == settingsId) ?? new Settings();
            
            var lookupStoreFront = settings.StoreFront ?? new StoreFront();

            if (lookupStoreFront.Id == Guid.Empty)
            {
                AdminPortalResources.ApplicationResources.StoreFronts.Add(storeFront);
                settings.StoreFront = storeFront;
                AdminPortalResources.ApplicationResources.SaveChanges();
            }
            else
            {
                lookupStoreFront.Address = storeFront.Address;
                lookupStoreFront.Address2 = storeFront.Address2;
                lookupStoreFront.City = storeFront.City;
                lookupStoreFront.State = storeFront.State;
                lookupStoreFront.Zip = storeFront.Zip;
                lookupStoreFront.ContactEmail = storeFront.ContactEmail;
                lookupStoreFront.ContactPhone = storeFront.ContactPhone;
                lookupStoreFront.BusinessName = storeFront.BusinessName;
                AdminPortalResources.ApplicationResources.Entry(lookupStoreFront).State = EntityState.Modified;
                AdminPortalResources.ApplicationResources.SaveChanges();
                if (lookupStoreFront.StoreAddress == null)
                    lookupStoreFront.StoreAddress = storeFront.StoreAddress;
                else
                {
                    lookupStoreFront.StoreAddress.State = storeFront.StoreAddress.State;
                    lookupStoreFront.StoreAddress.City = storeFront.StoreAddress.City;
                    lookupStoreFront.StoreAddress.Zip = storeFront.StoreAddress.Zip;
                    lookupStoreFront.StoreAddress.Street2 = storeFront.StoreAddress.Street2;
                    lookupStoreFront.StoreAddress.Street = storeFront.StoreAddress.Street;
                    lookupStoreFront.StoreAddress.Email = storeFront.StoreAddress.Email;
                    lookupStoreFront.StoreAddress.PhoneNumber = storeFront.StoreAddress.PhoneNumber;
                    lookupStoreFront.StoreAddress.LegalNameOfBusiness = storeFront.StoreAddress.LegalNameOfBusiness;
                }
                AdminPortalResources.ApplicationResources.Entry(lookupStoreFront).State = EntityState.Modified;
                AdminPortalResources.ApplicationResources.SaveChanges();
            }

            return Json(new { Success = true });
        }

        public virtual ActionResult Payments()
        {
            return View();
        }

        public virtual ActionResult Checkout()
        {
            return View();
        }

        public virtual ActionResult Shipping()
        {
            return View();
        }

        public virtual ActionResult Taxes()
        {
            return View();
        }

        public virtual ActionResult Files()
        {
            return View();
        }

        public virtual ActionResult Account()
        {
            return View();
        }



    }
}