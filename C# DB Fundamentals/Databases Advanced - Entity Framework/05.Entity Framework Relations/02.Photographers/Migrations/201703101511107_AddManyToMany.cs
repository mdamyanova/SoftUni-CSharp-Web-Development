namespace _02.Photographers.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddManyToMany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Albums", "Photographer_Id", c => c.Int());
            AddColumn("dbo.PhotographerAlbums", "Role", c => c.Int(nullable: false));
            CreateIndex("dbo.Albums", "Photographer_Id");
            AddForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Albums", "Photographer_Id", "dbo.Photographers");
            DropIndex("dbo.Albums", new[] { "Photographer_Id" });
            DropColumn("dbo.PhotographerAlbums", "Role");
            DropColumn("dbo.Albums", "Photographer_Id");
        }
    }
}
