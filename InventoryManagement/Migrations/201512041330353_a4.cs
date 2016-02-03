namespace InventoryManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerCategories", "CategoryName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerCategories", "CategoryName");
        }
    }
}
