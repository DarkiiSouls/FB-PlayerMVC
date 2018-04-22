namespace FootBallPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        ArticleId = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        PlayerId = c.Int(nullable: false),
                        VisterId = c.String(),
                        CoverPhoto = c.String(),
                        Visiter_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ArticleId)
                .ForeignKey("dbo.Players", t => t.PlayerId)
                .ForeignKey("dbo.AspNetUsers", t => t.Visiter_Id)
                .Index(t => t.PlayerId)
                .Index(t => t.Visiter_Id);
            
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
                        CoverPhotoPath = c.String(),
                        ImaId = c.Int(nullable: false),
                        Image_ImageId = c.Int(),
                        Masseges_Id = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Imags", t => t.Image_ImageId)
                .ForeignKey("dbo.Masseges", t => t.Masseges_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.PlayerUserId)
                .Index(t => t.PlayerUserId)
                .Index(t => t.Image_ImageId)
                .Index(t => t.Masseges_Id);
            
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
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Url = c.String(),
                        Discribtion = c.String(),
                        PlayerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Players", t => t.PlayerId, cascadeDelete: true)
                .Index(t => t.PlayerId);
            
            CreateTable(
                "dbo.Visters",
                c => new
                    {
                        VisitorUserId = c.String(),
                        VisterId = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        Age = c.Int(nullable: false),
                        Articals_ArticleId = c.Int(),
                        Masseges_Id = c.Int(),
                        VisterUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.VisterId)
                .ForeignKey("dbo.Articles", t => t.Articals_ArticleId)
                .ForeignKey("dbo.Masseges", t => t.Masseges_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.VisterUser_Id)
                .Index(t => t.Articals_ArticleId)
                .Index(t => t.Masseges_Id)
                .Index(t => t.VisterUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visters", "VisterUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Visters", "Masseges_Id", "dbo.Masseges");
            DropForeignKey("dbo.Visters", "Articals_ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Videos", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Followers", "VisiterId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Followers", "PlayerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "Visiter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articles", "PlayerId", "dbo.Players");
            DropForeignKey("dbo.Players", "PlayerUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Players", "Masseges_Id", "dbo.Masseges");
            DropForeignKey("dbo.Players", "Image_ImageId", "dbo.Imags");
            DropIndex("dbo.Visters", new[] { "VisterUser_Id" });
            DropIndex("dbo.Visters", new[] { "Masseges_Id" });
            DropIndex("dbo.Visters", new[] { "Articals_ArticleId" });
            DropIndex("dbo.Videos", new[] { "PlayerId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Followers", new[] { "PlayerId" });
            DropIndex("dbo.Followers", new[] { "VisiterId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Players", new[] { "Masseges_Id" });
            DropIndex("dbo.Players", new[] { "Image_ImageId" });
            DropIndex("dbo.Players", new[] { "PlayerUserId" });
            DropIndex("dbo.Articles", new[] { "Visiter_Id" });
            DropIndex("dbo.Articles", new[] { "PlayerId" });
            DropTable("dbo.Visters");
            DropTable("dbo.Videos");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Followers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Masseges");
            DropTable("dbo.Imags");
            DropTable("dbo.Players");
            DropTable("dbo.Articles");
        }
    }
}
