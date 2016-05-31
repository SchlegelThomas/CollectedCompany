using System.Data.Entity;
using CollectedCompany.Models.Shared;
using Microsoft.AspNet.Identity.EntityFramework;

namespace CollectedCompany.Models.Application
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<TeamWall> Walls { get; set; }
        public DbSet<TeamEntry> Entries { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Set> Sets { get; set; }
        
        public DbSet<AmazonIntegration> AmazonIntegrations { get; set; }
        public DbSet<EbayIntegration> EbayIntegrations { get; set; }
        public DbSet<FacebookIntegration> FacebookIntegrations { get; set; }
        public DbSet<InstagramIntegration> InstagramIntegrations { get; set; }
        public DbSet<TcgPlayerIntegration> TcgPlayerIntegrations { get; set; }
        public DbSet<TwitterIntegration> TwitterIntegrations { get; set; }
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

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


   
}