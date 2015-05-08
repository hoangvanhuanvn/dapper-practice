namespace DemoEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("store.Product", "Category_Id", "store.Category");
            DropIndex("store.Product", new[] { "Category_Id" });
            AddColumn("store.Product", "Stocks", c => c.Int(nullable: false));
            AlterColumn("store.Product", "Category_Id", c => c.Guid(nullable: false));
            CreateIndex("store.Product", "Category_Id");
            AddForeignKey("store.Product", "Category_Id", "store.Category", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("store.Product", "Category_Id", "store.Category");
            DropIndex("store.Product", new[] { "Category_Id" });
            AlterColumn("store.Product", "Category_Id", c => c.Guid());
            DropColumn("store.Product", "Stocks");
            CreateIndex("store.Product", "Category_Id");
            AddForeignKey("store.Product", "Category_Id", "store.Category", "Id");
        }
    }
}
