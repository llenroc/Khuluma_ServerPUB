namespace Khuluma_Server.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial001 : DbMigration
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
                        Gender = c.String(),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        HomeAddress = c.String(),
                        Notes = c.String(),
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
                "dbo.ChatMessages",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                        TimeStamp = c.DateTime(nullable: false),
                        Date = c.String(),
                        Time = c.String(),
                        timestampString = c.String(),
                        Name = c.String(),
                        Message = c.String(),
                        isFlagged = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ChatId);
            
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
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.PredefinedMessageModels", "GroupId", "dbo.GroupModels");
            DropForeignKey("dbo.AppUserModels", "LocationId", "dbo.LocationModels");
            DropForeignKey("dbo.AppUserModels", "GroupId", "dbo.GroupModels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.PredefinedMessageModels", new[] { "GroupId" });
            DropIndex("dbo.AppUserModels", new[] { "GroupId" });
            DropIndex("dbo.AppUserModels", new[] { "LocationId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.PredefinedMessageModels");
            DropTable("dbo.MobilePagesModels");
            DropTable("dbo.FlaggedContentModels");
            DropTable("dbo.ChatMessages");
            DropTable("dbo.LocationModels");
            DropTable("dbo.GroupModels");
            DropTable("dbo.AppUserModels");
        }
    }
}
