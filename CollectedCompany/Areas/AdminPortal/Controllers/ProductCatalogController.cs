using System;
using System.Linq;
using System.Web.Mvc;
using CollectedCompany.Models.Shared;
using CollectedCompany.ServiceLayer.Integrations.AdminPortal.Bindings;

namespace CollectedCompany.Areas.AdminPortal.Controllers
{
    public partial class ProductCatalogController : AdminBaseController
    {
        public ProductCatalogController(IAdminPortalResources adminResources)
            : base(adminResources)
        {

        }

        public virtual ActionResult Dashboard()
        {

            return View();
        }

        public virtual JsonResult GetProducts()
        {
            var products = AdminPortalResources.SharedResources.Products.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public virtual JsonResult GetCategories()
        {
            var products = AdminPortalResources.SharedResources.ProductCategories.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public virtual JsonResult GetSubCategories()
        {
            var products = AdminPortalResources.SharedResources.SubCategories.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public virtual JsonResult GetTags()
        {
            var products = AdminPortalResources.SharedResources.ProductTags.ToList();

            return JsonGetResponse(new { Success = true, Data = products });
        }

        public virtual JsonResult GetProductById(Guid id)
        {
            var product = AdminPortalResources.SharedResources.Products.FirstOrDefault(x => x.Id == id) ?? new Product();

            return JsonGetResponse(new { Success = true, Data = product });
        }

        public virtual JsonResult GetCategoryById(int id)
        {
            var product = AdminPortalResources.SharedResources.ProductCategories.FirstOrDefault(x => x.Id == id) ?? new ProductCategory();

            return JsonGetResponse(new { Success = true, Data = product });
        }

        public virtual JsonResult GetSubCategoryById(int id)
        {
            var product = AdminPortalResources.SharedResources.SubCategories.FirstOrDefault(x => x.Id == id) ?? new SubCategory();

            return JsonGetResponse(new { Success = true, Data = product });
        }

        public virtual JsonResult GetTagById(int id)
        {
            var product = AdminPortalResources.SharedResources.ProductTags.FirstOrDefault(x => x.Id == id) ?? new ProductTag();

            return JsonGetResponse(new { Success = true, Data = product });
        }



        public virtual JsonResult AddProduct(Product product)
        {

            return JsonGetResponse(new { Success = true });
        }




    }
}