namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class returndate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Book", "ReturnDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Book", "ReturnDate");
        }
    }
}
