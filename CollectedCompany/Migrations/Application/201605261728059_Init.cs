namespace CollectedCompany.Migrations.Application
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedById = c.Int(nullable: false),
                        ThumbNail = c.String(),
                        Content = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        PublishOn = c.DateTime(nullable: false),
                        TagCloud = c.String(),
                        CreatedBy_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatedBy_Id)
                .Index(t => t.CreatedBy_Id);
            
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
                        TeamEntry_Id = c.Guid(),
                        Team_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TeamEntries", t => t.TeamEntry_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.TeamEntry_Id)
                .Index(t => t.Team_Id);
            
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        CardId = c.Int(nullable: false, identity: true),
                        Layout = c.String(),
                        Name = c.String(),
                        Names = c.String(),
                        ManaCost = c.String(),
                        ConvertedManaCost = c.Int(nullable: false),
                        Type = c.String(),
                        SuperTypes = c.String(),
                        Types = c.String(),
                        SubTypes = c.String(),
                        Rarity = c.String(),
                        Text = c.String(),
                        Flavor = c.String(),
                        Artist = c.String(),
                        Number = c.String(),
                        Power = c.String(),
                        Toughness = c.String(),
                        Loyalty = c.String(),
                        MultiverseId = c.String(),
                        Variations = c.String(),
                        ImageName = c.String(),
                        Watermark = c.String(),
                        Timeshifted = c.Boolean(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        OurPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuantitySelling = c.Int(nullable: false),
                        QuantityBuying = c.Int(nullable: false),
                        SetId = c.Guid(nullable: false),
                        Mint = c.Int(nullable: false),
                        SlightPlay = c.Int(nullable: false),
                        ModeratePlay = c.Int(nullable: false),
                        HeavyPlay = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sets", t => t.SetId, cascadeDelete: true)
                .Index(t => t.SetId);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        GathererSetId = c.String(),
                        Name = c.String(),
                        Code = c.String(),
                        GathererCode = c.String(),
                        OldCode = c.String(),
                        MagicCardsInfoCode = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Type = c.String(),
                        Block = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contests",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TeamSize = c.Int(nullable: false),
                        Name = c.String(),
                        Rules = c.String(),
                        Scoring = c.String(),
                        EntryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventLink = c.String(),
                        Team_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.TeamEntries",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Contest_Id = c.Guid(),
                        Team_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Contests", t => t.Contest_Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Contest_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        Location = c.String(),
                        Bio = c.String(),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        Draws = c.Int(nullable: false),
                        Captain_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Captain_Id)
                .Index(t => t.Captain_Id);
            
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
                "dbo.InstagramIntegrations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstagramApiKey = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
                "dbo.TeamWalls",
                c => new
                    {
                        Id = c.Guid(nullable: false, identity: true),
                        Team_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Team_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamWalls", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.StoreFronts", "Twitter_Id", "dbo.TwitterIntegrations");
            DropForeignKey("dbo.StoreFronts", "Tcg_Id", "dbo.TcgPlayerIntegrations");
            DropForeignKey("dbo.Staffs", "StoreFront_Id", "dbo.StoreFronts");
            DropForeignKey("dbo.StoreFronts", "Instagram_Id", "dbo.InstagramIntegrations");
            DropForeignKey("dbo.StoreFronts", "Facebook_Id", "dbo.FacebookIntegrations");
            DropForeignKey("dbo.StoreFronts", "Ebay_Id", "dbo.EbayIntegrations");
            DropForeignKey("dbo.StoreFronts", "Amazon_Id", "dbo.AmazonIntegrations");
            DropForeignKey("dbo.Staffs", "UserAccount_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Products", "ShippingInformation_Id", "dbo.ShippingInformations");
            DropForeignKey("dbo.ProductVariants", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductImages", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.ProductInformations", "Vendor_Id", "dbo.ProductVendors");
            DropForeignKey("dbo.ProductTags", "ProductInformation_Id", "dbo.ProductInformations");
            DropForeignKey("dbo.ProductCategories", "ProductInformation_Id", "dbo.ProductInformations");
            DropForeignKey("dbo.SubCategories", "ProductCategory_Id", "dbo.ProductCategories");
            DropForeignKey("dbo.HtmlImageVariables", "HtmlTemplate_Id", "dbo.HtmlTemplates");
            DropForeignKey("dbo.HtmlFontSizeVariables", "HtmlTemplate_Id", "dbo.HtmlTemplates");
            DropForeignKey("dbo.HtmlColorVariables", "HtmlTemplate_Id", "dbo.HtmlTemplates");
            DropForeignKey("dbo.TeamEntries", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.AspNetUsers", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Contests", "Team_Id", "dbo.Teams");
            DropForeignKey("dbo.Teams", "Captain_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "TeamEntry_Id", "dbo.TeamEntries");
            DropForeignKey("dbo.TeamEntries", "Contest_Id", "dbo.Contests");
            DropForeignKey("dbo.Cards", "SetId", "dbo.Sets");
            DropForeignKey("dbo.Articles", "CreatedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TeamWalls", new[] { "Team_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Twitter_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Tcg_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Instagram_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Facebook_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Ebay_Id" });
            DropIndex("dbo.StoreFronts", new[] { "Amazon_Id" });
            DropIndex("dbo.Staffs", new[] { "StoreFront_Id" });
            DropIndex("dbo.Staffs", new[] { "UserAccount_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProductVariants", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "ShippingInformation_Id" });
            DropIndex("dbo.ProductTags", new[] { "ProductInformation_Id" });
            DropIndex("dbo.ProductInformations", new[] { "Vendor_Id" });
            DropIndex("dbo.ProductImages", new[] { "Product_Id" });
            DropIndex("dbo.SubCategories", new[] { "ProductCategory_Id" });
            DropIndex("dbo.ProductCategories", new[] { "ProductInformation_Id" });
            DropIndex("dbo.HtmlImageVariables", new[] { "HtmlTemplate_Id" });
            DropIndex("dbo.HtmlFontSizeVariables", new[] { "HtmlTemplate_Id" });
            DropIndex("dbo.HtmlColorVariables", new[] { "HtmlTemplate_Id" });
            DropIndex("dbo.Teams", new[] { "Captain_Id" });
            DropIndex("dbo.TeamEntries", new[] { "Team_Id" });
            DropIndex("dbo.TeamEntries", new[] { "Contest_Id" });
            DropIndex("dbo.Contests", new[] { "Team_Id" });
            DropIndex("dbo.Cards", new[] { "SetId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Team_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "TeamEntry_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Articles", new[] { "CreatedBy_Id" });
            DropTable("dbo.TeamWalls");
            DropTable("dbo.TwitterIntegrations");
            DropTable("dbo.TcgPlayerIntegrations");
            DropTable("dbo.StoreFronts");
            DropTable("dbo.Staffs");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ShippingInformations");
            DropTable("dbo.ProductVariants");
            DropTable("dbo.Products");
            DropTable("dbo.ProductVendors");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductInformations");
            DropTable("dbo.ProductImages");
            DropTable("dbo.SubCategories");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.InstagramIntegrations");
            DropTable("dbo.HtmlTemplates");
            DropTable("dbo.HtmlImageVariables");
            DropTable("dbo.HtmlFontSizeVariables");
            DropTable("dbo.HtmlColorVariables");
            DropTable("dbo.FacebookIntegrations");
            DropTable("dbo.EbayIntegrations");
            DropTable("dbo.Teams");
            DropTable("dbo.TeamEntries");
            DropTable("dbo.Contests");
            DropTable("dbo.Sets");
            DropTable("dbo.Cards");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Articles");
            DropTable("dbo.AmazonIntegrations");
        }
    }
}
