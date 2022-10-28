namespace Ishopping.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComponentSimpleProduct",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    DisplayOnPage = c.Boolean(nullable: false),
                    Name = c.String(nullable: false, maxLength: 64, unicode: false),
                    Category = c.Int(nullable: false),
                    SubCategory = c.Int(nullable: false),
                    Brand = c.String(maxLength: 32, unicode: false),
                    Model = c.String(maxLength: 32, unicode: false),
                    Description = c.String(nullable: false, maxLength: 512, unicode: false),
                    Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Tags = c.String(maxLength: 150, unicode: false),
                    ComponentSimpleProductOptionId = c.Guid(nullable: false),
                    Search = c.String(maxLength: 150, unicode: false),
                    SiteNumber = c.Int(nullable: false),
                    IdUser = c.String(maxLength: 150, unicode: false),
                    LastChange = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ComponentSimpleProductOption", t => t.ComponentSimpleProductOptionId, cascadeDelete: true)
                .Index(t => t.ComponentSimpleProductOptionId);

            CreateTable(
                "dbo.ComponentSimpleProductOption",
                c => new
                {
                    Id = c.Guid(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 64, unicode: false),
                    Category = c.String(nullable: false, maxLength: 64, unicode: false),
                    Brand = c.String(nullable: false, maxLength: 64, unicode: false),
                    Model = c.String(nullable: false, maxLength: 64, unicode: false),
                    Description = c.String(nullable: false, maxLength: 64, unicode: false),
                    Price = c.String(nullable: false, maxLength: 64, unicode: false),
                    Default = c.Boolean(nullable: false),
                    IdUser = c.String(maxLength: 150, unicode: false),
                    LastChange = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.ComponentSimpleProductUserImageGallery",
                c => new
                {
                    ComponentSimpleProduct_Id = c.Guid(nullable: false),
                    UserImageGallery_Id = c.Guid(nullable: false),
                })
                .PrimaryKey(t => new { t.ComponentSimpleProduct_Id, t.UserImageGallery_Id })
                .ForeignKey("dbo.ComponentSimpleProduct", t => t.ComponentSimpleProduct_Id, cascadeDelete: true)
                .ForeignKey("dbo.UserImageGallery", t => t.UserImageGallery_Id, cascadeDelete: true)
                .Index(t => t.ComponentSimpleProduct_Id)
                .Index(t => t.UserImageGallery_Id);
        }              
    }
}
