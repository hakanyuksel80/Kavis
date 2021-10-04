namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ara : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "KurumId" });
            DropColumn("dbo.Birimler", "KurumId");
            DropTable("dbo.Kurumlar");
        }
        
        public override void Down()
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
            
            AddColumn("dbo.Birimler", "KurumId", c => c.Int());
            CreateIndex("dbo.Birimler", "KurumId");
            AddForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar", "Id");
        }
    }
}
