namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurumBirim : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Birimler", "Kurum_Id", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "Kurum_Id" });
            RenameColumn(table: "dbo.Birimler", name: "Kurum_Id", newName: "KurumId");
            AlterColumn("dbo.Birimler", "KurumId", c => c.Int(nullable: false));
            CreateIndex("dbo.Birimler", "KurumId");
            AddForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Birimler", "KurumId", "dbo.Kurumlar");
            DropIndex("dbo.Birimler", new[] { "KurumId" });
            AlterColumn("dbo.Birimler", "KurumId", c => c.Int());
            RenameColumn(table: "dbo.Birimler", name: "KurumId", newName: "Kurum_Id");
            CreateIndex("dbo.Birimler", "Kurum_Id");
            AddForeignKey("dbo.Birimler", "Kurum_Id", "dbo.Kurumlar", "Id");
        }
    }
}
