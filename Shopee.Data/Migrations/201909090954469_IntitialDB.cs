namespace Shopee.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntitialDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerId", c => c.String(maxLength: 128));
            AddColumn("dbo.Products", "MoreImages", c => c.String(storeType: "xml"));
            AddColumn("dbo.Products", "Tags", c => c.String());
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "OriginalPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Orders", "PaymentStatus", c => c.String());
            AlterColumn("dbo.Products", "ViewCount", c => c.Int());
            AlterColumn("dbo.Posts", "ViewCount", c => c.Int());
            CreateIndex("dbo.Orders", "CustomerId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers", "Id");
            DropColumn("dbo.Products", "MoreImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "MoreImage", c => c.String(storeType: "xml"));
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.ApplicationUsers");
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.Posts", "ViewCount", c => c.Boolean());
            AlterColumn("dbo.Products", "ViewCount", c => c.Boolean());
            AlterColumn("dbo.Orders", "PaymentStatus", c => c.String(nullable: false));
            DropColumn("dbo.Products", "OriginalPrice");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Tags");
            DropColumn("dbo.Products", "MoreImages");
            DropColumn("dbo.Orders", "CustomerId");
        }
    }
}
