namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Borrow", "ReaderId", "dbo.Reader");
            DropIndex("dbo.Borrow", new[] { "ReaderId" });
            AddColumn("dbo.Book", "Author", c => c.String(nullable: false));
            AddColumn("dbo.Book", "Publisher", c => c.String(nullable: false));
            AddColumn("dbo.Book", "PublishingDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Book", "Isbn", c => c.String(nullable: false, maxLength: 13));
            AddColumn("dbo.Book", "BorrowDate", c => c.DateTime());
            AddColumn("dbo.Book", "Reader_ID", c => c.Int());
            AlterColumn("dbo.Book", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "Street", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "HouseNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "PostalCode", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "PhoneNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Reader", "Email", c => c.String(nullable: false));
            CreateIndex("dbo.Book", "Reader_ID");
            AddForeignKey("dbo.Book", "Reader_ID", "dbo.Reader", "ID");
            DropColumn("dbo.Reader", "Surname");
            DropTable("dbo.BorrowBook");
            DropTable("dbo.Borrow");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Borrow",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BorrowDate = c.DateTime(nullable: false),
                        ReaderId = c.Int(nullable: false),
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
            
            AddColumn("dbo.Reader", "Surname", c => c.String());
            DropForeignKey("dbo.Book", "Reader_ID", "dbo.Reader");
            DropIndex("dbo.Book", new[] { "Reader_ID" });
            AlterColumn("dbo.Reader", "Email", c => c.String());
            AlterColumn("dbo.Reader", "PhoneNumber", c => c.String());
            AlterColumn("dbo.Reader", "City", c => c.String());
            AlterColumn("dbo.Reader", "PostalCode", c => c.String());
            AlterColumn("dbo.Reader", "HouseNumber", c => c.String());
            AlterColumn("dbo.Reader", "Street", c => c.String());
            AlterColumn("dbo.Reader", "Name", c => c.String());
            AlterColumn("dbo.Book", "Title", c => c.String());
            DropColumn("dbo.Book", "Reader_ID");
            DropColumn("dbo.Book", "BorrowDate");
            DropColumn("dbo.Book", "Isbn");
            DropColumn("dbo.Book", "PublishingDate");
            DropColumn("dbo.Book", "Publisher");
            DropColumn("dbo.Book", "Author");
            CreateIndex("dbo.Borrow", "ReaderId");
            AddForeignKey("dbo.Borrow", "ReaderId", "dbo.Reader", "ID", cascadeDelete: true);
        }
    }
}
