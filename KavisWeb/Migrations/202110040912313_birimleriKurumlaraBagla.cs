namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birimleriKurumlaraBagla : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Birimler", "KurumId", c => c.Int());
            CreateIndex("dbo.Birimler", "KurumId");
            AddForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "KurumId" });
            DropColumn("dbo.Birimler", "KurumId");
        }
    }
}
