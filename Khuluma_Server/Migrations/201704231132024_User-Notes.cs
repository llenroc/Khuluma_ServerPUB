namespace Khuluma_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserModels", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUserModels", "Notes");
        }
    }
}
