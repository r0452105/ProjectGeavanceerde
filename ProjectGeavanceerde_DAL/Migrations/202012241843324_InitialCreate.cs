namespace ProjectGeavanceerde_DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Affiliations",
                c => new
                    {
                        AffiliationID = c.Int(nullable: false, identity: true),
                        FactionID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.AffiliationID)
                .ForeignKey("dbo.Factions", t => t.FactionID, cascadeDelete: true)
                .Index(t => t.FactionID);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        FactionID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.FactionID);
            
            CreateTable(
                "dbo.Arcs",
                c => new
                    {
                        ArcID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        Startingchapter = c.Int(nullable: false),
                        Endingchapter = c.Int(),
                    })
                .PrimaryKey(t => t.ArcID);
            
            CreateTable(
                "dbo.Arcs_Places",
                c => new
                    {
                        Arc_PlaceID = c.Int(nullable: false, identity: true),
                        PlaceID = c.Int(nullable: false),
                        ArcID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Arc_PlaceID)
                .ForeignKey("dbo.Arcs", t => t.ArcID, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID)
                .Index(t => t.ArcID);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        PlaceID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        Ruler = c.String(maxLength: 75),
                        Location = c.String(nullable: false, maxLength: 40),
                        Country = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.PlaceID);
            
            CreateTable(
                "dbo.Characters_Places",
                c => new
                    {
                        Character_PlaceID = c.Int(nullable: false, identity: true),
                        PlaceID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Character_PlaceID)
                .ForeignKey("dbo.Characters", t => t.CharacterID, cascadeDelete: true)
                .ForeignKey("dbo.Places", t => t.PlaceID, cascadeDelete: true)
                .Index(t => t.PlaceID)
                .Index(t => t.CharacterID);
            
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        CharacterID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        DevilFruit = c.String(maxLength: 75),
                        DevilFruitText = c.String(),
                        Bounty = c.Decimal(precision: 18, scale: 2),
                        Birthday = c.DateTime(nullable: false),
                        BloodtypeID = c.Int(nullable: false),
                        SpeciesID = c.Int(nullable: false),
                        HakiID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CharacterID)
                .ForeignKey("dbo.Bloodtypes", t => t.BloodtypeID, cascadeDelete: true)
                .ForeignKey("dbo.Genders", t => t.GenderID, cascadeDelete: true)
                .ForeignKey("dbo.Hakis", t => t.HakiID, cascadeDelete: true)
                .ForeignKey("dbo.Species", t => t.SpeciesID, cascadeDelete: true)
                .Index(t => t.BloodtypeID)
                .Index(t => t.SpeciesID)
                .Index(t => t.HakiID)
                .Index(t => t.GenderID);
            
            CreateTable(
                "dbo.Bloodtypes",
                c => new
                    {
                        BloodtypeID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.BloodtypeID);
            
            CreateTable(
                "dbo.Characters_Affiliations",
                c => new
                    {
                        Character_AffiliationID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                        Current = c.Boolean(nullable: false),
                        AffiliationID = c.Int(nullable: false),
                        CharacterID = c.Int(nullable: false),
                        Leader = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Character_AffiliationID)
                .ForeignKey("dbo.Affiliations", t => t.AffiliationID, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.AffiliationID)
                .Index(t => t.CharacterID);
            
            CreateTable(
                "dbo.Characters_Arcs",
                c => new
                    {
                        Character_ArcID = c.Int(nullable: false, identity: true),
                        CharacterID = c.Int(nullable: false),
                        ArcID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Character_ArcID)
                .ForeignKey("dbo.Arcs", t => t.ArcID, cascadeDelete: true)
                .ForeignKey("dbo.Characters", t => t.CharacterID, cascadeDelete: true)
                .Index(t => t.CharacterID)
                .Index(t => t.ArcID);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        GenderID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.GenderID);
            
            CreateTable(
                "dbo.Hakis",
                c => new
                    {
                        HakiID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.HakiID);
            
            CreateTable(
                "dbo.Species",
                c => new
                    {
                        SpeciesID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 75),
                    })
                .PrimaryKey(t => t.SpeciesID);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventID = c.Int(nullable: false, identity: true),
                        Omschrijving = c.String(nullable: false, maxLength: 2500),
                        Date = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EventID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Characters_Places", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Characters", "SpeciesID", "dbo.Species");
            DropForeignKey("dbo.Characters", "HakiID", "dbo.Hakis");
            DropForeignKey("dbo.Characters", "GenderID", "dbo.Genders");
            DropForeignKey("dbo.Characters_Places", "CharacterID", "dbo.Characters");
            DropForeignKey("dbo.Characters_Arcs", "CharacterID", "dbo.Characters");
            DropForeignKey("dbo.Characters_Arcs", "ArcID", "dbo.Arcs");
            DropForeignKey("dbo.Characters_Affiliations", "CharacterID", "dbo.Characters");
            DropForeignKey("dbo.Characters_Affiliations", "AffiliationID", "dbo.Affiliations");
            DropForeignKey("dbo.Characters", "BloodtypeID", "dbo.Bloodtypes");
            DropForeignKey("dbo.Arcs_Places", "PlaceID", "dbo.Places");
            DropForeignKey("dbo.Arcs_Places", "ArcID", "dbo.Arcs");
            DropForeignKey("dbo.Affiliations", "FactionID", "dbo.Factions");
            DropIndex("dbo.Characters_Arcs", new[] { "ArcID" });
            DropIndex("dbo.Characters_Arcs", new[] { "CharacterID" });
            DropIndex("dbo.Characters_Affiliations", new[] { "CharacterID" });
            DropIndex("dbo.Characters_Affiliations", new[] { "AffiliationID" });
            DropIndex("dbo.Characters", new[] { "GenderID" });
            DropIndex("dbo.Characters", new[] { "HakiID" });
            DropIndex("dbo.Characters", new[] { "SpeciesID" });
            DropIndex("dbo.Characters", new[] { "BloodtypeID" });
            DropIndex("dbo.Characters_Places", new[] { "CharacterID" });
            DropIndex("dbo.Characters_Places", new[] { "PlaceID" });
            DropIndex("dbo.Arcs_Places", new[] { "ArcID" });
            DropIndex("dbo.Arcs_Places", new[] { "PlaceID" });
            DropIndex("dbo.Affiliations", new[] { "FactionID" });
            DropTable("dbo.Events");
            DropTable("dbo.Species");
            DropTable("dbo.Hakis");
            DropTable("dbo.Genders");
            DropTable("dbo.Characters_Arcs");
            DropTable("dbo.Characters_Affiliations");
            DropTable("dbo.Bloodtypes");
            DropTable("dbo.Characters");
            DropTable("dbo.Characters_Places");
            DropTable("dbo.Places");
            DropTable("dbo.Arcs_Places");
            DropTable("dbo.Arcs");
            DropTable("dbo.Factions");
            DropTable("dbo.Affiliations");
        }
    }
}
