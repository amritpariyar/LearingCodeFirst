namespace LearingCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyupdateddataannotationadded : DbMigration
    {
        public override void Up()
        {
            // Remove the problematic foreign key relationship from StockItems table
            DropForeignKey("dbo.StockItems", "Invoice_Id", "dbo.Invoices");
            DropIndex("dbo.StockItems", new[] { "Invoice_Id" });
            DropColumn("dbo.StockItems", "Invoice_Id");
            
            // Add InvoiceNumber column to Invoices
            AddColumn("dbo.Invoices", "InvoiceNumber", c => c.Int(nullable: false));
            
            // Update Customer Name constraints
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 100));
            
            // Create proper foreign key relationship: Invoice -> StockItem
            CreateIndex("dbo.Invoices", "StockItemId");
            AddForeignKey("dbo.Invoices", "StockItemId", "dbo.StockItems", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            // Reverse all operations
            DropForeignKey("dbo.Invoices", "StockItemId", "dbo.StockItems");
            DropIndex("dbo.Invoices", new[] { "StockItemId" });
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Invoices", "InvoiceNumber");
            
            // Restore the old relationship
            AddColumn("dbo.StockItems", "Invoice_Id", c => c.Int());
            CreateIndex("dbo.StockItems", "Invoice_Id");
            AddForeignKey("dbo.StockItems", "Invoice_Id", "dbo.Invoices", "Id");
        }
    }
}
