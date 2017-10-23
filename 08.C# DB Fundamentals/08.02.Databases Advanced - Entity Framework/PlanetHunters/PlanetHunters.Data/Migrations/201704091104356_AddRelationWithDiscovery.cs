namespace PlanetHunters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRelationWithDiscovery : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Publications", "DiscoveryId", "dbo.Discoveries");
            DropIndex("dbo.Publications", new[] { "DiscoveryId" });
            DropColumn("dbo.Publications", "Id");
            RenameColumn(table: "dbo.Publications", name: "DiscoveryId", newName: "Id");
            DropPrimaryKey("dbo.Publications");
            AlterColumn("dbo.Publications", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Publications", "Id");
            CreateIndex("dbo.Publications", "Id");
            AddForeignKey("dbo.Publications", "Id", "dbo.Discoveries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Publications", "Id", "dbo.Discoveries");
            DropIndex("dbo.Publications", new[] { "Id" });
            DropPrimaryKey("dbo.Publications");
            AlterColumn("dbo.Publications", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Publications", "Id");
            RenameColumn(table: "dbo.Publications", name: "Id", newName: "DiscoveryId");
            AddColumn("dbo.Publications", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Publications", "DiscoveryId");
            AddForeignKey("dbo.Publications", "DiscoveryId", "dbo.Discoveries", "Id", cascadeDelete: true);
        }
    }
}
