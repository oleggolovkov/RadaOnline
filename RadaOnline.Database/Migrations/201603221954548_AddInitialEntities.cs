namespace RadaOnline.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInitialEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Council",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 256),
                        Size = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Session",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                        IsRegular = c.Boolean(nullable: false),
                        Council_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Council", t => t.Council_Id)
                .Index(t => t.Council_Id);
            
            CreateTable(
                "dbo.SessionItem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 1024),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Url = c.String(maxLength: 1024),
                        Status = c.Int(nullable: false),
                        Session_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Session", t => t.Session_Id)
                .Index(t => t.Session_Id);
            
            CreateTable(
                "dbo.Decision",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(maxLength: 1024),
                        Type = c.Int(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                        Url = c.String(maxLength: 1024),
                        SessionItem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SessionItem", t => t.SessionItem_Id)
                .Index(t => t.SessionItem_Id);
            
            CreateTable(
                "dbo.Vote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Councilman_Id = c.Int(),
                        Decision_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Councilman", t => t.Councilman_Id)
                .ForeignKey("dbo.Decision", t => t.Decision_Id)
                .Index(t => t.Councilman_Id)
                .Index(t => t.Decision_Id);
            
            AddColumn("dbo.Councilman", "ProfileImage", c => c.String(maxLength: 1024));
            AddColumn("dbo.Councilman", "IsChairman", c => c.Boolean(nullable: false));
            AddColumn("dbo.Councilman", "Council_Id", c => c.Int());
            AddColumn("dbo.Fraction", "Council_Id", c => c.Int());
            AlterColumn("dbo.Councilman", "FullName", c => c.String(maxLength: 256));
            AlterColumn("dbo.Fraction", "Name", c => c.String(maxLength: 256));
            CreateIndex("dbo.Councilman", "Council_Id");
            CreateIndex("dbo.Fraction", "Council_Id");
            AddForeignKey("dbo.Councilman", "Council_Id", "dbo.Council", "Id");
            AddForeignKey("dbo.Fraction", "Council_Id", "dbo.Council", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SessionItem", "Session_Id", "dbo.Session");
            DropForeignKey("dbo.Vote", "Decision_Id", "dbo.Decision");
            DropForeignKey("dbo.Vote", "Councilman_Id", "dbo.Councilman");
            DropForeignKey("dbo.Decision", "SessionItem_Id", "dbo.SessionItem");
            DropForeignKey("dbo.Session", "Council_Id", "dbo.Council");
            DropForeignKey("dbo.Fraction", "Council_Id", "dbo.Council");
            DropForeignKey("dbo.Councilman", "Council_Id", "dbo.Council");
            DropIndex("dbo.Vote", new[] { "Decision_Id" });
            DropIndex("dbo.Vote", new[] { "Councilman_Id" });
            DropIndex("dbo.Decision", new[] { "SessionItem_Id" });
            DropIndex("dbo.SessionItem", new[] { "Session_Id" });
            DropIndex("dbo.Session", new[] { "Council_Id" });
            DropIndex("dbo.Fraction", new[] { "Council_Id" });
            DropIndex("dbo.Councilman", new[] { "Council_Id" });
            AlterColumn("dbo.Fraction", "Name", c => c.String());
            AlterColumn("dbo.Councilman", "FullName", c => c.String());
            DropColumn("dbo.Fraction", "Council_Id");
            DropColumn("dbo.Councilman", "Council_Id");
            DropColumn("dbo.Councilman", "IsChairman");
            DropColumn("dbo.Councilman", "ProfileImage");
            DropTable("dbo.Vote");
            DropTable("dbo.Decision");
            DropTable("dbo.SessionItem");
            DropTable("dbo.Session");
            DropTable("dbo.Council");
        }
    }
}
