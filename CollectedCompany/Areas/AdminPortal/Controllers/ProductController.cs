
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using CollectedCompany.Models;
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
            var products = AdminPortalResources.ApplicationResources.Products.ToList();

            return PartialView("_ProductListing", products);
        }

        public virtual PartialViewResult ProductDetails(Guid productId)
        {
            var product = AdminPortalResources.ApplicationResources.Products.FirstOrDefault(x => x.Id == productId) ?? new Product
            {
                ImageUrl = "http://www.konvertra.com/sites/default/files/default_images/default_product.jpg"
            };

            return PartialView("_ProductDetails", product);
        }

        public virtual JsonResult SaveProduct(String title, String description)
        {
            var test = new Product
            {
                Description = description,
                Title = title
            };

            AdminPortalResources.ApplicationResources.Products.Add(test);
            AdminPortalResources.ApplicationResources.SaveChanges();


            return Json(new {Success = true, Id = test.Id }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public virtual JsonResult DeleteProduct(Guid productId)
        {
            var productLookup = AdminPortalResources.ApplicationResources.Products.FirstOrDefault(x => x.Id == productId);

            if (productLookup != null)
            {
                AdminPortalResources.ApplicationResources.Products.Remove(productLookup);
                AdminPortalResources.ApplicationResources.SaveChanges();
            }


            return Json(new { Success = true });
        }




        public virtual JsonResult SaveImage(Guid productId)
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            var product = AdminPortalResources.ApplicationResources.Products.FirstOrDefault(x => x.Id == productId);
            try
            {
                if (product != null) { 
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    
                    fName = file.FileName;
                    if (file != null && file.ContentLength > 0)
                    {
                        var webPath = GetTempSavedFilePath(file, file.FileName).Replace("/", "\\");
                        var imageLookup = new WebImage(Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(webPath)));

                        String azureImageUrl = AdminPortalResources.ImageStorageService.SaveImage(new FileStream(imageLookup.FileName, FileMode.Open), imageLookup.FileName + Guid.NewGuid(), "productimages");

                        product.ImageUrl = azureImageUrl;

                        AdminPortalResources.ApplicationResources.SaveChanges();
                    }
                }
}
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            if (isSavedSuccessfully)
            {
                return Json(new { Success = true, Message = fName }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { Success = false, Message = "Error in saving file" }, JsonRequestBehavior.AllowGet);
        }


        public virtual JsonResult SaveImageToGallery(Guid productId)
        {
            bool isSavedSuccessfully = true;
            string fName = "";
            var product = AdminPortalResources.ApplicationResources.Products.FirstOrDefault(x => x.Id == productId);
            try
            {
                if (product != null)
                {
                    foreach (string fileName in Request.Files)
                    {
                        HttpPostedFileBase file = Request.Files[fileName];

                        fName = file.FileName;
                        if (file != null && file.ContentLength > 0)
                        {
                            var webPath = GetTempSavedFilePath(file, file.FileName).Replace("/", "\\");
                            var imageLookup = new WebImage(Path.Combine(Server.MapPath(MapTempFolder), Path.GetFileName(webPath)));

                            String azureImageUrl = AdminPortalResources.ImageStorageService.SaveImage(new FileStream(imageLookup.FileName, FileMode.Open), imageLookup.FileName + Guid.NewGuid(), "productgallery");

                            ProductImage newImage = new ProductImage
                            {
                                ImageUrl = azureImageUrl
                            };

                            product.Images.Add(newImage);
                            AdminPortalResources.ApplicationResources.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isSavedSuccessfully = false;
            }
            if (isSavedSuccessfully)
            {
                return Json(new { Success = true, Message = fName }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { Success = false, Message = "Error in saving file" }, JsonRequestBehavior.AllowGet);
        }



    }
}