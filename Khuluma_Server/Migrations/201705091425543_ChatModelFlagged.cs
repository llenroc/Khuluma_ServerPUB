namespace Khuluma_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChatModelFlagged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChatMessages", "isFlagged", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ChatMessages", "isFlagged");
        }
    }
}
