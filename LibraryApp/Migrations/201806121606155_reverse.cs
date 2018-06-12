namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reverse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Borrow", "BookId", "dbo.Book");
            DropForeignKey("dbo.BorrowBook", "BookId", "dbo.Book");
            DropIndex("dbo.Borrow", new[] { "BookId" });
            DropIndex("dbo.BorrowBook", new[] { "BookId" });
            DropColumn("dbo.Borrow", "BookId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Borrow", "BookId", c => c.Int(nullable: false));
            CreateIndex("dbo.BorrowBook", "BookId");
            CreateIndex("dbo.Borrow", "BookId");
            AddForeignKey("dbo.BorrowBook", "BookId", "dbo.Book", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Borrow", "BookId", "dbo.Book", "Id", cascadeDelete: true);
        }
    }
}
