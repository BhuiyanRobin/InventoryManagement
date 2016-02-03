namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PurchasePrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PurchasePrice");
        }
    }
}
