namespace CollectedCompany.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductInformationFKFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ProductInformation_Id", c => c.Int());
            CreateIndex("dbo.Products", "ProductInformation_Id");
            AddForeignKey("dbo.Products", "ProductInformation_Id", "dbo.ProductInformations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "ProductInformation_Id", "dbo.ProductInformations");
            DropIndex("dbo.Products", new[] { "ProductInformation_Id" });
            DropColumn("dbo.Products", "ProductInformation_Id");
        }
    }
}
