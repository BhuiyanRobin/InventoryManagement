namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InvoiceNumber = c.String(),
                        CustomerId = c.Int(nullable: false),
                        ShipTo = c.String(),
                        ProductCategoryId = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        TotalAmount = c.Double(nullable: false),
                        PurchaseDate = c.DateTime(nullable: false),
                        ShipingDate = c.DateTime(nullable: false),
                        Discount = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                        TaxType1 = c.Double(nullable: false),
                        TaxType2 = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.ProductCategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderTables", "ProductCategoryId", "dbo.ProductCategories");
            DropForeignKey("dbo.OrderTables", "CustomerId", "dbo.Customers");
            DropIndex("dbo.OrderTables", new[] { "ProductCategoryId" });
            DropIndex("dbo.OrderTables", new[] { "CustomerId" });
            DropTable("dbo.OrderTables");
        }
    }
}
