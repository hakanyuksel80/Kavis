namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Faaliyet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faaliyetler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EylemId = c.Int(nullable: false),
                        Baslama = c.DateTime(nullable: false),
                        Bitis = c.DateTime(nullable: false),
                        Gerceklesme = c.String(),
                        Sonuc = c.String(),
                        Durum = c.String(),
                        Birim = c.String(),
                        Kod = c.String(),
                        Baslik = c.String(),
                        SiraNo = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eylemler", t => t.EylemId, cascadeDelete: true)
                .Index(t => t.EylemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Faaliyetler", "EylemId", "dbo.Eylemler");
            DropIndex("dbo.Faaliyetler", new[] { "EylemId" });
            DropTable("dbo.Faaliyetler");
        }
    }
}
