namespace CollectedCompany.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUrlToTemplates : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HtmlTemplates", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HtmlTemplates", "ImageUrl");
        }
    }
}
