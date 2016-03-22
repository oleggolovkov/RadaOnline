namespace RadaOnline.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CouncilmanFraction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ValidUntil = c.DateTime(),
                        Councilman_Id = c.Int(),
                        Fraction_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Councilman", t => t.Councilman_Id)
                .ForeignKey("dbo.Fraction", t => t.Fraction_Id)
                .Index(t => t.Councilman_Id)
                .Index(t => t.Fraction_Id);
            
            CreateTable(
                "dbo.Councilman",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fraction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CouncilmanFraction", "Fraction_Id", "dbo.Fraction");
            DropForeignKey("dbo.CouncilmanFraction", "Councilman_Id", "dbo.Councilman");
            DropIndex("dbo.CouncilmanFraction", new[] { "Fraction_Id" });
            DropIndex("dbo.CouncilmanFraction", new[] { "Councilman_Id" });
            DropTable("dbo.Fraction");
            DropTable("dbo.Councilman");
            DropTable("dbo.CouncilmanFraction");
        }
    }
}
