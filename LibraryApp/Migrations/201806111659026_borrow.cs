namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class borrow : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Borrow", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.Borrow", "BookId");
            AddForeignKey("dbo.Borrow", "BookId", "dbo.Book", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrow", "BookId", "dbo.Book");
            DropIndex("dbo.Borrow", new[] { "BookId" });
            DropColumn("dbo.Borrow", "BookId");
        }
    }
}
