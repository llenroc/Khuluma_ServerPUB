namespace Khuluma_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Controllers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatMessages",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        timestampString = c.String(),
                        Name = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.ChatId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ChatMessages");
        }
    }
}
