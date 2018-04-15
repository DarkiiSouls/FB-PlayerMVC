namespace FootBallPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class d : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articals",
                c => new
                    {
                        ArticalId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PlayerId = c.Int(nullable: false),
                        VisterId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ArticalId);
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        VisiterId = c.String(nullable: false, maxLength: 128),
                        PlayerId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.VisiterId, t.PlayerId })
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.VisiterId, cascadeDelete: false)
                .Index(t => t.VisiterId)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        NiceName = c.String(),
                        YourName = c.String(),
                        PhoneNum = c.String(),
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
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Imags",
                c => new
                    {
                        Name = c.String(),
                        ImageId = c.Int(nullable: false, identity: true),
                        PlayerUserId = c.String(),
                        Path = c.String(),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ImageId);
            
            CreateTable(
                "dbo.Masseges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PlayerId = c.Int(nullable: false),
                        VisterId = c.String(),
                        Name = c.String(),
                        Time = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        PlayerUserId = c.String(maxLength: 128),
                        PlayerId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Height = c.Double(nullable: false),
                        Weight = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        Detail = c.String(),
                        DataTime = c.DateTime(nullable: false),
                        ImaId = c.Int(nullable: false),
                        Articals_ArticalId = c.Int(),
                        Image_ImageId = c.Int(),
                        Masseges_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Articals", t => t.Articals_ArticalId)
                .ForeignKey("dbo.Imags", t => t.Image_ImageId)
                .ForeignKey("dbo.Masseges", t => t.Masseges_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerUserId)
                .Index(t => t.PlayerUserId)
                .Index(t => t.Articals_ArticalId)
                .Index(t => t.Image_ImageId)
                .Index(t => t.Masseges_Id);
            
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
                "dbo.Visters",
                c => new
                    {
                        VisitorUserId = c.String(),
                        VisterId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Articals_ArticalId = c.Int(),
                        Masseges_Id = c.Int(),
                        VisterUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VisterId)
                .ForeignKey("dbo.Articals", t => t.Articals_ArticalId)
                .ForeignKey("dbo.Masseges", t => t.Masseges_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.VisterUser_Id)
                .Index(t => t.Articals_ArticalId)
                .Index(t => t.Masseges_Id)
                .Index(t => t.VisterUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visters", "VisterUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Visters", "Masseges_Id", "dbo.Masseges");
            DropForeignKey("dbo.Visters", "Articals_ArticalId", "dbo.Articals");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Players", "PlayerUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Players", "Masseges_Id", "dbo.Masseges");
            DropForeignKey("dbo.Players", "Image_ImageId", "dbo.Imags");
            DropForeignKey("dbo.Players", "Articals_ArticalId", "dbo.Articals");
            DropForeignKey("dbo.Followers", "VisiterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "PlayerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Visters", new[] { "VisterUser_Id" });
            DropIndex("dbo.Visters", new[] { "Masseges_Id" });
            DropIndex("dbo.Visters", new[] { "Articals_ArticalId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Players", new[] { "Masseges_Id" });
            DropIndex("dbo.Players", new[] { "Image_ImageId" });
            DropIndex("dbo.Players", new[] { "Articals_ArticalId" });
            DropIndex("dbo.Players", new[] { "PlayerUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Followers", new[] { "PlayerId" });
            DropIndex("dbo.Followers", new[] { "VisiterId" });
            DropTable("dbo.Visters");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Players");
            DropTable("dbo.Masseges");
            DropTable("dbo.Imags");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Followers");
            DropTable("dbo.Articals");
        }
    }
}
