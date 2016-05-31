using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CollectedCompany.Models.Shared
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public virtual ICollection<ProductImage> Images { get; set; }

        public String ImageUrl { get; set; }

        public decimal Price { get; set; }

        public decimal CompareAtPrice { get; set; }

        public String StockKeepingUnit { get; set; }

        public String Barcode { get; set; }

        public int Quantity { get; set; }

        public Boolean AllowPurchaseWhenOutOfStock { get; set; }

        public Boolean RequiresShipping { get; set; }

        public virtual ProductInformation ProductInformation { get; set; }

        public virtual ShippingInformation ShippingInformation { get; set; }

        public virtual ICollection<ProductVariant> ProductVariants { get; set; }
    }


    public class ProductImage
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String ImageUrl { get; set; }

    }

    public class ShippingInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Decimal Weight { get; set; }

        public String TarriffCode { get; set; }
    }

    public class ProductVariant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Description { get; set; }

        public String ImageUrl { get; set; }

        public String Title { get; set; }

        public int Quantity { get; set; }
    }

    public class ProductInformation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String ProductType { get; set; }

        public virtual ProductVendor Vendor { get; set; }

        public virtual ICollection<ProductCategory> ProductCategories { get; set; }

        public virtual ICollection<ProductTag> ProductTags { get; set; }

    }

    public class ProductTag
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Description { get; set; }
    }

    public class ProductVendor
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Description { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }

        public String DistributorContactEmail { get; set; }

    }
}