namespace CollectedCompany.Migrations.Application
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Settings : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StoreAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LegalNameOfBusiness = c.String(),
                        PhoneNumber = c.String(),
                        Street = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        State = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.StoreFronts", "StoreAddress_Id", c => c.Int());
            CreateIndex("dbo.StoreFronts", "StoreAddress_Id");
            AddForeignKey("dbo.StoreFronts", "StoreAddress_Id", "dbo.StoreAddresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoreFronts", "StoreAddress_Id", "dbo.StoreAddresses");
            DropIndex("dbo.StoreFronts", new[] { "StoreAddress_Id" });
            DropColumn("dbo.StoreFronts", "StoreAddress_Id");
            DropTable("dbo.StoreAddresses");
        }
    }
}
