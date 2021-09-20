namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amaclar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StratejikPlanId = c.Int(nullable: false),
                        Kod = c.String(),
                        Baslik = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Plans", t => t.StratejikPlanId, cascadeDelete: true)
                .Index(t => t.StratejikPlanId);
            
            CreateTable(
                "dbo.Hedefler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kod = c.String(),
                        Baslik = c.String(),
                        Amac_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Amaclar", t => t.Amac_Id)
                .Index(t => t.Amac_Id);
            
            CreateTable(
                "dbo.Gostergeler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HedefeEtkisi = c.String(),
                        Baslangic = c.String(),
                        Yil1 = c.String(),
                        Yil2 = c.String(),
                        Yil3 = c.String(),
                        Yil4 = c.String(),
                        Yil5 = c.String(),
                        Yil1G = c.String(),
                        Yil2G = c.String(),
                        Yil3G = c.String(),
                        Yil4G = c.String(),
                        Yil5G = c.String(),
                        Kod = c.String(),
                        Baslik = c.String(),
                        Hedef_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hedefler", t => t.Hedef_Id)
                .Index(t => t.Hedef_Id);
            
            CreateTable(
                "dbo.Stratejiler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Kod = c.String(),
                        Baslik = c.String(),
                        Hedef_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hedefler", t => t.Hedef_Id)
                .Index(t => t.Hedef_Id);
            
            CreateTable(
                "dbo.Plans",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KurumKodu = c.Int(nullable: false),
                        KurumAdi = c.String(),
                        Baslangic = c.Int(nullable: false),
                        Bitis = c.Int(nullable: false),
                        KurumTipi = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Amaclar", "StratejikPlanId", "dbo.Plans");
            DropForeignKey("dbo.Stratejiler", "Hedef_Id", "dbo.Hedefler");
            DropForeignKey("dbo.Gostergeler", "Hedef_Id", "dbo.Hedefler");
            DropForeignKey("dbo.Hedefler", "Amac_Id", "dbo.Amaclar");
            DropIndex("dbo.Stratejiler", new[] { "Hedef_Id" });
            DropIndex("dbo.Gostergeler", new[] { "Hedef_Id" });
            DropIndex("dbo.Hedefler", new[] { "Amac_Id" });
            DropIndex("dbo.Amaclar", new[] { "StratejikPlanId" });
            DropTable("dbo.Plans");
            DropTable("dbo.Stratejiler");
            DropTable("dbo.Gostergeler");
            DropTable("dbo.Hedefler");
            DropTable("dbo.Amaclar");
        }
    }
}
