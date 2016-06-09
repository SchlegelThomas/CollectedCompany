using System;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Controllers.Api
{
    public class CityStateController : Controller
    {
        public IAdminPortalResources AdminPortalResources;

        public CityStateController(IAdminPortalResources adminPortalResources)
        {
            AdminPortalResources = adminPortalResources;
        }

        public JsonResult GetCities(String stateAbbreviation)
        {
            var cities = AdminPortalResources.CityStateApi.GetCitiesByState(stateAbbreviation);   

            return Json(new { Success = true, Data = cities}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetStates()
        {
            var states = AdminPortalResources.CityStateApi.GetStates();

            return Json(new { Success = true, Data = states }, JsonRequestBehavior.AllowGet);
        }

    }
}
