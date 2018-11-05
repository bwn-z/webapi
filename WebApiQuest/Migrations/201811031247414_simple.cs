namespace WebApiQuest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class simple : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        PurchaseId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        SizeTableId = c.Int(nullable: false),
                        Name = c.String(),
                        LastDateOrder = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.PurchaseId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.SizeTables", t => t.SizeTableId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SizeTableId);
            
            CreateTable(
                "dbo.SizeTables",
                c => new
                    {
                        SizeTableId = c.Int(nullable: false, identity: true),
                        SizeGuid = c.String(),
                        SizeDescription = c.String(),
                    })
                .PrimaryKey(t => t.SizeTableId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Purchases", "SizeTableId", "dbo.SizeTables");
            DropForeignKey("dbo.Purchases", "ProductId", "dbo.Products");
            DropIndex("dbo.Purchases", new[] { "SizeTableId" });
            DropIndex("dbo.Purchases", new[] { "ProductId" });
            DropTable("dbo.SizeTables");
            DropTable("dbo.Purchases");
            DropTable("dbo.Products");
        }
    }
}
