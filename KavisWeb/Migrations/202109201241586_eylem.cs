namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eylem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Eylemler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Birim = c.String(),
                        StratejiId = c.Int(nullable: false),
                        Kod = c.String(),
                        Baslik = c.String(),
                        SiraNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stratejiler", t => t.StratejiId, cascadeDelete: true)
                .Index(t => t.StratejiId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Eylemler", "StratejiId", "dbo.Stratejiler");
            DropIndex("dbo.Eylemler", new[] { "StratejiId" });
            DropTable("dbo.Eylemler");
        }
    }
}
