namespace Thuisbezorgd_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gerecht", "CategorieId", "dbo.GerechtCategorie");
            DropIndex("dbo.Gerecht", new[] { "CategorieId" });
            CreateTable(
                "dbo.Vraag",
                c => new
                    {
                        Aantal = c.Int(nullable: false, identity: true),
                        Tekst = c.String(),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Aantal)
                .ForeignKey("dbo.GerechtCategorie", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId);
            
            DropTable("dbo.Gerecht");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Gerecht",
                c => new
                    {
                        GerechtId = c.Int(nullable: false, identity: true),
                        Naam = c.String(),
                        Prijs = c.Double(nullable: false),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GerechtId);
            
            DropForeignKey("dbo.Vraag", "CategorieId", "dbo.GerechtCategorie");
            DropIndex("dbo.Vraag", new[] { "CategorieId" });
            DropTable("dbo.Vraag");
            CreateIndex("dbo.Gerecht", "CategorieId");
            AddForeignKey("dbo.Gerecht", "CategorieId", "dbo.GerechtCategorie", "Id", cascadeDelete: true);
        }
    }
}
