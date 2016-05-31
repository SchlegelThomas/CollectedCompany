namespace CollectedCompany.Migrations.Shared
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HtmlColorVariables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CssSelector = c.String(),
                        Value = c.String(),
                        HtmlTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HtmlTemplates", t => t.HtmlTemplate_Id)
                .Index(t => t.HtmlTemplate_Id);
            
            CreateTable(
                "dbo.HtmlFontSizeVariables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CssSelector = c.String(),
                        Value = c.String(),
                        HtmlTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HtmlTemplates", t => t.HtmlTemplate_Id)
                .Index(t => t.HtmlTemplate_Id);
            
            CreateTable(
                "dbo.HtmlImageVariables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CssSelector = c.String(),
                        Value = c.String(),
                        HtmlTemplate_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HtmlTemplates", t => t.HtmlTemplate_Id)
                .Index(t => t.HtmlTemplate_Id);
            
            CreateTable(
                "dbo.HtmlTemplates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsActive = c.Boolean(nullable: false),
                        Name = c.String(),
                        TemplateUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        ProductCategory_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategory_Id)
                .Index(t => t.ProductCategory_Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StoreFronts",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        LogoImageUrl = c.String(),
                        BusinessName = c.String(),
                        FavIconUrl = c.String(),
                        ContactEmail = c.String(),
                        Address = c.String(),
                        ContactPhone = c.String(),
                        TimeZoneId = c.String(),
                        Amazon_Id = c.Int(),
                        Ebay_Id = c.Int(),
                        Facebook_Id = c.Int(),
                        Instagram_Id = c.Int(),
                        Tcg_Id = c.Int(),
                        Twitter_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AmazonIntegrations", t => t.Amazon_Id)
                .ForeignKey("dbo.EbayIntegrations", t => t.Ebay_Id)
                .ForeignKey("dbo.FacebookIntegrations", t => t.Facebook_Id)
                .ForeignKey("dbo.InstagramIntegrations", t => t.Instagram_Id)
                .ForeignKey("dbo.TcgPlayerIntegrations", t => t.Tcg_Id)
                .ForeignKey("dbo.TwitterIntegrations", t => t.Twitter_Id)
                .Index(t => t.Amazon_Id)
                .Index(t => t.Ebay_Id)
                .Index(t => t.Facebook_Id)
                .Index(t => t.Instagram_Id)
                .Index(t => t.Tcg_Id)
                .Index(t => t.Twitter_Id);
            
            CreateTable(
                "dbo.AmazonIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AmazonApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EbayIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EbayApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FacebookIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FacebookApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InstagramIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstagramApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TcgPlayerIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TcgPlayerApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TwitterIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TwitterApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DciNumber = c.String(nullable: false, maxLength: 10),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Premium = c.Boolean(),
                        UserType = c.Int(nullable: false),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        Draws = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StoreFronts", "Twitter_Id", "dbo.TwitterIntegrations");
            DropForeignKey("dbo.StoreFronts", "Tcg_Id", "dbo.TcgPlayerIntegrations");
            DropForeignKey("dbo.StoreFronts", "Instagram_Id", "dbo.InstagramIntegrations");
            DropForeignKey("dbo.StoreFronts", "Facebook_Id", "dbo.FacebookIntegrations");
            DropForeignKey("dbo.StoreFronts", "Ebay_Id", "dbo.EbayIntegrations");
            DropForeignKey("dbo.StoreFronts", "Amazon_Id", "dbo.AmazonIntegrations");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.SubCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.HtmlImageVariables", "HtmlTemplate_Id", "dbo.HtmlTemplates");
            DropForeignKey("dbo.HtmlFontSizeVariables", "HtmlTemplate_Id", "dbo.HtmlTemplates");
            DropForeignKey("dbo.HtmlColorVariables", "HtmlTemplate_Id", "dbo.HtmlTemplates");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StoreFronts", new[] { "Twitter_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Tcg_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Instagram_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Facebook_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Ebay_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Amazon_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.SubCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.HtmlImageVariables", new[] { "HtmlTemplate_Id" });
            DropIndex("dbo.HtmlFontSizeVariables", new[] { "HtmlTemplate_Id" });
            DropIndex("dbo.HtmlColorVariables", new[] { "HtmlTemplate_Id" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.TwitterIntegrations");
            DropTable("dbo.TcgPlayerIntegrations");
            DropTable("dbo.InstagramIntegrations");
            DropTable("dbo.FacebookIntegrations");
            DropTable("dbo.EbayIntegrations");
            DropTable("dbo.AmazonIntegrations");
            DropTable("dbo.StoreFronts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.SubCategories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.HtmlTemplates");
            DropTable("dbo.HtmlImageVariables");
            DropTable("dbo.HtmlFontSizeVariables");
            DropTable("dbo.HtmlColorVariables");
        }
    }
}
