namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Borrows : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BorrowBook",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BorrowId = c.Int(nullable: false),
                        BookId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Borrow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BorrowDate = c.DateTime(nullable: false),
                        ReaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reader", t => t.ReaderId, cascadeDelete: true)
                .Index(t => t.ReaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Borrow", "ReaderId", "dbo.Reader");
            DropIndex("dbo.Borrow", new[] { "ReaderId" });
            DropTable("dbo.Borrow");
            DropTable("dbo.BorrowBook");
            DropTable("dbo.Book");
        }
    }
}
