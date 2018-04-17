namespace FootBallPlayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class articals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Articals", "PublishDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Articals", "ImagId", c => c.Int(nullable: false));
            AddColumn("dbo.Articals", "imag_ImageId", c => c.Int());
            AddColumn("dbo.Articals", "Player_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Articals", "Visiter_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Articals", "imag_ImageId");
            CreateIndex("dbo.Articals", "Player_Id");
            CreateIndex("dbo.Articals", "Visiter_Id");
            AddForeignKey("dbo.Articals", "imag_ImageId", "dbo.Imags", "ImageId");
            AddForeignKey("dbo.Articals", "Player_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Articals", "Visiter_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Articals", "Visiter_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articals", "Player_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articals", "imag_ImageId", "dbo.Imags");
            DropIndex("dbo.Articals", new[] { "Visiter_Id" });
            DropIndex("dbo.Articals", new[] { "Player_Id" });
            DropIndex("dbo.Articals", new[] { "imag_ImageId" });
            DropColumn("dbo.Articals", "Visiter_Id");
            DropColumn("dbo.Articals", "Player_Id");
            DropColumn("dbo.Articals", "imag_ImageId");
            DropColumn("dbo.Articals", "ImagId");
            DropColumn("dbo.Articals", "PublishDate");
        }
    }
}
