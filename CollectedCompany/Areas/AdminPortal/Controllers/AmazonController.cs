using System;
using System.Web.Mvc;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;
using CollectedCompany.ServiceLayer.Integrations.Amazon.Bindings;
using Nager.AmazonProductAdvertising.Model;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public partial class AmazonController : AdminBaseController
    {
        private readonly IAmazonProductAdvertisingService _amazonService;

        public AmazonController(IAdminPortalResources adminResources, IAmazonProductAdvertisingService amazonService) 
            : base(adminResources)
        {
            _amazonService = amazonService;
        }

        public virtual ActionResult AmazonProductList()
        {
            
            
            return View();
        }

        public virtual PartialViewResult Search(String searchTerms, AmazonSearchIndex category)
        {
            var results = _amazonService.Search(searchTerms, category);

            return PartialView("_SearchResults", results);
        }
    }
}