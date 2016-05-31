
using System.Data.Entity;
using CollectedCompany.Models.Application;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CollectedCompany.Models.Shared
{
    public class SharedDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<StoreFront> StoreFronts { get; set; }
        public DbSet<HtmlTemplate> HtmlTemplates { get; set; }
        public DbSet<HtmlColorVariable> HtmlColors { get; set; }
        public DbSet<HtmlFontSizeVariable> HtmlFonts { get; set; }
        public DbSet<HtmlImageVariable> HtmlImages { get; set; }


        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ShippingInformation> ShippingInformation { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<ProductInformation> ProductInformation { get; set; }
        public DbSet<ProductTag> ProductTags { get; set; }
        public DbSet<ProductVendor> ProductVendors { get; set; }
        public DbSet<Staff> StaffMembers { get; set; }


        public SharedDbContext()
            : base("SharedConnection", throwIfV1Schema: false)
        {
        }

        public static SharedDbContext Create()
        {
            return new SharedDbContext();
        }
    }
}