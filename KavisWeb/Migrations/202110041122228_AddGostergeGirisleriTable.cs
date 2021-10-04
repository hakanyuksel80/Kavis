namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGostergeGirisleriTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GostergeGirisleri",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GostergeId = c.Int(nullable: false),
                        Yil = c.Byte(nullable: false),
                        BirimId = c.Int(nullable: false),
                        Onay = c.Boolean(nullable: false),
                        Deger = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Birimler", t => t.BirimId, cascadeDelete: true)
                .ForeignKey("dbo.Gostergeler", t => t.GostergeId, cascadeDelete: true)
                .Index(t => t.GostergeId)
                .Index(t => t.BirimId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GostergeGirisleri", "GostergeId", "dbo.Gostergeler");
            DropForeignKey("dbo.GostergeGirisleri", "BirimId", "dbo.Birimler");
            DropIndex("dbo.GostergeGirisleri", new[] { "BirimId" });
            DropIndex("dbo.GostergeGirisleri", new[] { "GostergeId" });
            DropTable("dbo.GostergeGirisleri");
        }
    }
}
