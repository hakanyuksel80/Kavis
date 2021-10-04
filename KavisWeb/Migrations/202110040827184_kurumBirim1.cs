namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurumBirim1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "KurumId" });
            AlterColumn("dbo.Birimler", "KurumId", c => c.Int());
            CreateIndex("dbo.Birimler", "KurumId");
            AddForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "KurumId" });
            AlterColumn("dbo.Birimler", "KurumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Birimler", "KurumId");
            AddForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar", "Id", cascadeDelete: true);
        }
    }
}
