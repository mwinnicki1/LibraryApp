namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.BorrowBook", "BookId");
            AddForeignKey("dbo.BorrowBook", "BookId", "dbo.Book", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BorrowBook", "BookId", "dbo.Book");
            DropIndex("dbo.BorrowBook", new[] { "BookId" });
        }
    }
}
