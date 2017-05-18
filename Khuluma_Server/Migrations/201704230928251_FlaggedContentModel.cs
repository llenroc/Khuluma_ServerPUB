namespace Khuluma_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FlaggedContentModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUserModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Age = c.Int(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        HomeAddress = c.String(),
                        ParticipantId = c.String(),
                        LocationId = c.Int(),
                        GroupId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupModels", t => t.GroupId)
                .ForeignKey("dbo.LocationModels", t => t.LocationId)
                .Index(t => t.LocationId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.GroupModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        Active = c.Boolean(nullable: false),
                        NumberofMembers = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LocationModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        HospitalName = c.String(),
                        Province = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.FlaggedContentModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ContentText = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MobilePagesModels",
                c => new
                    {
                        PageId = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(),
                        PageHTMLContent = c.String(),
                    })
                .PrimaryKey(t => t.PageId);
            
            CreateTable(
                "dbo.PredefinedMessageModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MessageText = c.String(),
                        GroupId = c.Int(),
                        time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.GroupModels", t => t.GroupId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PredefinedMessageModels", "GroupId", "dbo.GroupModels");
            DropForeignKey("dbo.AppUserModels", "LocationId", "dbo.LocationModels");
            DropForeignKey("dbo.AppUserModels", "GroupId", "dbo.GroupModels");
            DropIndex("dbo.PredefinedMessageModels", new[] { "GroupId" });
            DropIndex("dbo.AppUserModels", new[] { "GroupId" });
            DropIndex("dbo.AppUserModels", new[] { "LocationId" });
            DropTable("dbo.PredefinedMessageModels");
            DropTable("dbo.MobilePagesModels");
            DropTable("dbo.FlaggedContentModels");
            DropTable("dbo.LocationModels");
            DropTable("dbo.GroupModels");
            DropTable("dbo.AppUserModels");
        }
    }
}
