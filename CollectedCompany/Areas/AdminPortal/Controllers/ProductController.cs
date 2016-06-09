
using System;
using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class ProductController : AdminBaseController
    {
        public ProductController(IAdminPortalResources adminResources) 
            : base(adminResources)
        {
            
        }

        public virtual ActionResult Dashboard()
        {
            return View();
        }


        public virtual PartialViewResult ProductListing()
        {
            var products = AdminPortalResources.SharedResources.Products.ToList();

            return PartialView("_ProductListing", products);
        }

        public virtual PartialViewResult ProductDetails(Guid productId)
        {
            var product = AdminPortalResources.SharedResources.Products.FirstOrDefault(x => x.Id == productId) ?? new Product();

            return PartialView("_ProductDetails", product);
        }

        public virtual JsonResult SaveProduct(Product product)
        {
            return Json(new {Success = true}, JsonRequestBehavior.AllowGet);
        }





    }
}