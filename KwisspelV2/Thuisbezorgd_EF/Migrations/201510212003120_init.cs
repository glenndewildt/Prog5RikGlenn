namespace Thuisbezorgd_EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Antwoord",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Tekst = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GerechtCategorie",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vraag", "CategorieId", "dbo.GerechtCategorie");
            DropIndex("dbo.Vraag", new[] { "CategorieId" });
            DropTable("dbo.Vraag");
            DropTable("dbo.GerechtCategorie");
            DropTable("dbo.Antwoord");
        }
    }
}
