namespace Thuisbezorgd_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GerechtCategorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Gerecht",
                c => new
                    {
                        GerechtId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Prijs = c.Double(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GerechtId)
                .ForeignKey("dbo.GerechtCategorie", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gerecht", "CategorieId", "dbo.GerechtCategorie");
            DropIndex("dbo.Gerecht", new[] { "CategorieId" });
            DropTable("dbo.Gerecht");
            DropTable("dbo.GerechtCategorie");
        }
    }
}
