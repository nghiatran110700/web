namespace Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class web : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Account",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(nullable: false, maxLength: 50, unicode: false),
                        password = c.String(nullable: false, maxLength: 50, unicode: false),
                        fullname = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.category",
                c => new
                    {
                        idcategory = c.Int(nullable: false),
                        name = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => t.idcategory);
            
            CreateTable(
                "dbo.Product",
                c => new
                    {
                        id = c.Int(nullable: false),
                        name = c.String(maxLength: 50, unicode: false),
                        amount = c.Int(),
                        pirce = c.Decimal(precision: 18, scale: 2),
                        idcategory = c.Int(),
                        photo = c.String(maxLength: 50, unicode: false),
                        description = c.String(unicode: false, storeType: "text"),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.category", t => t.idcategory)
                .Index(t => t.idcategory);
            
            CreateTable(
                "dbo.ProductDTOes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        pirce = c.Decimal(precision: 18, scale: 2),
                        amount = c.Int(),
                        description = c.String(),
                        photo = c.String(),
                        idcategory = c.Int(),
                        cateName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "idcategory", "dbo.category");
            DropIndex("dbo.Product", new[] { "idcategory" });
            DropTable("dbo.ProductDTOes");
            DropTable("dbo.Product");
            DropTable("dbo.category");
            DropTable("dbo.Account");
        }
    }
}
