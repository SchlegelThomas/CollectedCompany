namespace CollectedCompany.Migrations.Application
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Settings1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        AccountEmail = c.String(),
                        CustomerEmail = c.String(),
                        StoreFront_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StoreFronts", t => t.StoreFront_Id)
                .Index(t => t.StoreFront_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Settings", "StoreFront_Id", "dbo.StoreFronts");
            DropIndex("dbo.Settings", new[] { "StoreFront_Id" });
            DropTable("dbo.Settings");
        }
    }
}
