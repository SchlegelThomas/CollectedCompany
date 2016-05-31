using System;
using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public class ProductCatalogController : AdminBaseController
    {
        public ProductCatalogController(IAdminPortalResources adminResources)
            : base(adminResources)
        {

        }

        public ActionResult Dashboard()
        {

            return View();
        }

        public JsonResult GetProducts()
        {
            var products = AdminPortalResources.SharedResources.Products.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public JsonResult GetCategories()
        {
            var products = AdminPortalResources.SharedResources.ProductCategories.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public JsonResult GetSubCategories()
        {
            var products = AdminPortalResources.SharedResources.SubCategories.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public JsonResult GetTags()
        {
            var products = AdminPortalResources.SharedResources.ProductTags.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public JsonResult GetProductById(Guid id)
        {
            var product = AdminPortalResources.SharedResources.Products.FirstOrDefault(x => x.Id == id) ?? new Product();

            return JsonGetResponse(new { Success = true, Data = product });
        }

        public JsonResult GetCategoryById(int id)
        {
            var product = AdminPortalResources.SharedResources.ProductCategories.FirstOrDefault(x => x.Id == id) ?? new ProductCategory();

            return JsonGetResponse(new { Success = true, Data = product });
        }

        public JsonResult GetSubCategoryById(int id)
        {
            var product = AdminPortalResources.SharedResources.SubCategories.FirstOrDefault(x => x.Id == id) ?? new SubCategory();

            return JsonGetResponse(new { Success = true, Data = product });
        }

        public JsonResult GetTagById(int id)
        {
            var product = AdminPortalResources.SharedResources.ProductTags.FirstOrDefault(x => x.Id == id) ?? new ProductTag();

            return JsonGetResponse(new { Success = true, Data = product });
        }



        public JsonResult AddProduct(Product product)
        {

            return JsonGetResponse(new { Success = true });
        }




    }
}