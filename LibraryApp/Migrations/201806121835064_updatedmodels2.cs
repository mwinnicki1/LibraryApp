namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Book", name: "Reader_ID", newName: "ReaderId");
            RenameIndex(table: "dbo.Book", name: "IX_Reader_ID", newName: "IX_ReaderId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Book", name: "IX_ReaderId", newName: "IX_Reader_ID");
            RenameColumn(table: "dbo.Book", name: "ReaderId", newName: "Reader_ID");
        }
    }
}
