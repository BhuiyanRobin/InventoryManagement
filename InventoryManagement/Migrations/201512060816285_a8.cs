namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Discount", c => c.Double(nullable: false));
            AddColumn("dbo.CustomerCategories", "Discount", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerCategories", "Discount");
            DropColumn("dbo.Customers", "Discount");
        }
    }
}
