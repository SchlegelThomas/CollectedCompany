namespace CollectedCompany.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductDatabaseDetails : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ProductInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductType = c.String(),
                        Vendor_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductVendors", t => t.Vendor_Id)
                .Index(t => t.Vendor_Id);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductInformations", t => t.ProductInformation_Id)
                .Index(t => t.ProductInformation_Id);
            
            CreateTable(
                "dbo.ProductVendors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Name = c.String(),
                        Address = c.String(),
                        DistributorContactEmail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CompareAtPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StockKeepingUnit = c.String(),
                        Barcode = c.String(),
                        Quantity = c.Int(nullable: false),
                        AllowPurchaseWhenOutOfStock = c.Boolean(nullable: false),
                        RequiresShipping = c.Boolean(nullable: false),
                        ShippingInformation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShippingInformations", t => t.ShippingInformation_Id)
                .Index(t => t.ShippingInformation_Id);
            
            CreateTable(
                "dbo.ProductVariants",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.ShippingInformations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TarriffCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserAccount_Id = c.String(maxLength: 128),
                        StoreFront_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserAccount_Id)
                .ForeignKey("dbo.StoreFronts", t => t.StoreFront_Id)
                .Index(t => t.UserAccount_Id)
                .Index(t => t.StoreFront_Id);
            
            AddColumn("dbo.ProductCategories", "ProductInformation_Id", c => c.Int());
            CreateIndex("dbo.ProductCategories", "ProductInformation_Id");
            AddForeignKey("dbo.ProductCategories", "ProductInformation_Id", "dbo.ProductInformations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Staffs", "StoreFront_Id", "dbo.StoreFronts");
            DropForeignKey("dbo.Staffs", "UserAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Products", "ShippingInformation_Id", "dbo.ShippingInformations");
            DropForeignKey("dbo.ProductVariants", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductInformations", "Vendor_Id", "dbo.ProductVendors");
            DropForeignKey("dbo.ProductTags", "ProductInformation_Id", "dbo.ProductInformations");
            DropForeignKey("dbo.ProductCategories", "ProductInformation_Id", "dbo.ProductInformations");
            DropIndex("dbo.Staffs", new[] { "StoreFront_Id" });
            DropIndex("dbo.Staffs", new[] { "UserAccount_Id" });
            DropIndex("dbo.ProductVariants", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ShippingInformation_Id" });
            DropIndex("dbo.ProductTags", new[] { "ProductInformation_Id" });
            DropIndex("dbo.ProductInformations", new[] { "Vendor_Id" });
            DropIndex("dbo.ProductImages", new[] { "Product_Id" });
            DropIndex("dbo.ProductCategories", new[] { "ProductInformation_Id" });
            DropColumn("dbo.ProductCategories", "ProductInformation_Id");
            DropTable("dbo.Staffs");
            DropTable("dbo.ShippingInformations");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Products");
            DropTable("dbo.ProductVendors");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductInformations");
            DropTable("dbo.ProductImages");
        }
    }
}
