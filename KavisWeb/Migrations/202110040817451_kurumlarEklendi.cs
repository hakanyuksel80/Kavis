namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurumlarEklendi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kurumlar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        KurumKodu = c.Int(nullable: false),
                        Adi = c.String(),
                        Turu = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Plans", "KurumId", c => c.Int(nullable: false));
            AddColumn("dbo.Birimler", "Kurum_Id", c => c.Int());
            AddColumn("dbo.Faaliyetler", "Yil", c => c.Byte(nullable: false));
            AddColumn("dbo.Faaliyetler", "Onay1", c => c.Boolean(nullable: false));
            AddColumn("dbo.Faaliyetler", "Onay2", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Birimler", "Kurum_Id");
            AddForeignKey("dbo.Birimler", "Kurum_Id", "dbo.Kurumlar", "Id");
            DropColumn("dbo.Plans", "KurumKodu");
            DropColumn("dbo.Plans", "KurumAdi");
            DropColumn("dbo.Plans", "KurumTipi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Plans", "KurumTipi", c => c.Int(nullable: false));
            AddColumn("dbo.Plans", "KurumAdi", c => c.String());
            AddColumn("dbo.Plans", "KurumKodu", c => c.Int(nullable: false));
            DropForeignKey("dbo.Birimler", "Kurum_Id", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "Kurum_Id" });
            DropColumn("dbo.Faaliyetler", "Onay2");
            DropColumn("dbo.Faaliyetler", "Onay1");
            DropColumn("dbo.Faaliyetler", "Yil");
            DropColumn("dbo.Birimler", "Kurum_Id");
            DropColumn("dbo.Plans", "KurumId");
            DropTable("dbo.Kurumlar");
        }
    }
}
