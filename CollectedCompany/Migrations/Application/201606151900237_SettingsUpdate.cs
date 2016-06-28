namespace CollectedCompany.Migrations.Application
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StoreFronts", "Address2", c => c.String());
            AddColumn("dbo.StoreFronts", "State", c => c.String());
            AddColumn("dbo.StoreFronts", "City", c => c.String());
            AddColumn("dbo.StoreFronts", "Zip", c => c.String());
            AddColumn("dbo.StoreAddresses", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.StoreAddresses", "Email");
            DropColumn("dbo.StoreFronts", "Zip");
            DropColumn("dbo.StoreFronts", "City");
            DropColumn("dbo.StoreFronts", "State");
            DropColumn("dbo.StoreFronts", "Address2");
        }
    }
}
