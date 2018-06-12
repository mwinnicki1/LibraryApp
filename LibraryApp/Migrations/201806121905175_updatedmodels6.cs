namespace LibraryApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedmodels6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reader", "PostalCode2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reader", "PostalCode2");
        }
    }
}
