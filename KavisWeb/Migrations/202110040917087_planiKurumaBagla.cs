namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class planiKurumaBagla : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Plans", "KurumId", c => c.Int());
            CreateIndex("dbo.Plans", "KurumId");
            AddForeignKey("dbo.Plans", "KurumId", "dbo.Kurumlar", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plans", "KurumId", "dbo.Kurumlar");
            DropIndex("dbo.Plans", new[] { "KurumId" });
            AlterColumn("dbo.Plans", "KurumId", c => c.Int(nullable: false));
        }
    }
}
