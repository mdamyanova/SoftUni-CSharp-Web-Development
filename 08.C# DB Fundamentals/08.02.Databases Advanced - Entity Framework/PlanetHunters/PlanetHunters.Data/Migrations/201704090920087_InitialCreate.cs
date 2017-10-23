namespace PlanetHunters.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Astronomers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discoveries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateMade = c.DateTime(nullable: false, storeType: "date"),
                        TelescopeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Telescopes", t => t.TelescopeId, cascadeDelete: true)
                .Index(t => t.TelescopeId);
            
            CreateTable(
                "dbo.Planets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Mass = c.Double(nullable: false),
                        StarSystemId = c.Int(nullable: false),
                        DiscoveryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryId)
                .ForeignKey("dbo.StarSystems", t => t.StarSystemId, cascadeDelete: true)
                .Index(t => t.StarSystemId)
                .Index(t => t.DiscoveryId);
            
            CreateTable(
                "dbo.StarSystems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Temperature = c.Int(nullable: false),
                        StarSystemId = c.Int(nullable: false),
                        DiscoveryId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryId)
                .ForeignKey("dbo.StarSystems", t => t.StarSystemId, cascadeDelete: true)
                .Index(t => t.StarSystemId)
                .Index(t => t.DiscoveryId);
            
            CreateTable(
                "dbo.Telescopes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        MirrorDiameter = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ObserversDiscoveriesObserved",
                c => new
                    {
                        DiscoveryObservedId = c.Int(nullable: false),
                        ObserverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscoveryObservedId, t.ObserverId })
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryObservedId, cascadeDelete: true)
                .ForeignKey("dbo.Astronomers", t => t.ObserverId, cascadeDelete: true)
                .Index(t => t.DiscoveryObservedId)
                .Index(t => t.ObserverId);
            
            CreateTable(
                "dbo.PioneersDiscoveriesMade",
                c => new
                    {
                        DiscoveryMadeId = c.Int(nullable: false),
                        PioneerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DiscoveryMadeId, t.PioneerId })
                .ForeignKey("dbo.Discoveries", t => t.DiscoveryMadeId, cascadeDelete: true)
                .ForeignKey("dbo.Astronomers", t => t.PioneerId, cascadeDelete: true)
                .Index(t => t.DiscoveryMadeId)
                .Index(t => t.PioneerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discoveries", "TelescopeId", "dbo.Telescopes");
            DropForeignKey("dbo.Planets", "StarSystemId", "dbo.StarSystems");
            DropForeignKey("dbo.Stars", "StarSystemId", "dbo.StarSystems");
            DropForeignKey("dbo.Stars", "DiscoveryId", "dbo.Discoveries");
            DropForeignKey("dbo.Planets", "DiscoveryId", "dbo.Discoveries");
            DropForeignKey("dbo.PioneersDiscoveriesMade", "PioneerId", "dbo.Astronomers");
            DropForeignKey("dbo.PioneersDiscoveriesMade", "DiscoveryMadeId", "dbo.Discoveries");
            DropForeignKey("dbo.ObserversDiscoveriesObserved", "ObserverId", "dbo.Astronomers");
            DropForeignKey("dbo.ObserversDiscoveriesObserved", "DiscoveryObservedId", "dbo.Discoveries");
            DropIndex("dbo.PioneersDiscoveriesMade", new[] { "PioneerId" });
            DropIndex("dbo.PioneersDiscoveriesMade", new[] { "DiscoveryMadeId" });
            DropIndex("dbo.ObserversDiscoveriesObserved", new[] { "ObserverId" });
            DropIndex("dbo.ObserversDiscoveriesObserved", new[] { "DiscoveryObservedId" });
            DropIndex("dbo.Stars", new[] { "DiscoveryId" });
            DropIndex("dbo.Stars", new[] { "StarSystemId" });
            DropIndex("dbo.Planets", new[] { "DiscoveryId" });
            DropIndex("dbo.Planets", new[] { "StarSystemId" });
            DropIndex("dbo.Discoveries", new[] { "TelescopeId" });
            DropTable("dbo.PioneersDiscoveriesMade");
            DropTable("dbo.ObserversDiscoveriesObserved");
            DropTable("dbo.Telescopes");
            DropTable("dbo.Stars");
            DropTable("dbo.StarSystems");
            DropTable("dbo.Planets");
            DropTable("dbo.Discoveries");
            DropTable("dbo.Astronomers");
        }
    }
}
