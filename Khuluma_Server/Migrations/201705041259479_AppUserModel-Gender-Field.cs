namespace Khuluma_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppUserModelGenderField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AppUserModels", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AppUserModels", "Gender");
        }
    }
}
