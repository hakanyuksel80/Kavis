namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurumAyarlarieklendi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kurumlar", "AktifYil", c => c.Int(nullable: false));
            AddColumn("dbo.Kurumlar", "FaaliyetGirisAcik", c => c.Boolean(nullable: false));
            AddColumn("dbo.Kurumlar", "FaaliyetDurumGirisAcik", c => c.Boolean(nullable: false));
            AddColumn("dbo.Kurumlar", "GostergeGirisAcik", c => c.Boolean(nullable: false));
            AddColumn("dbo.Kurumlar", "Mesaj", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kurumlar", "Mesaj");
            DropColumn("dbo.Kurumlar", "GostergeGirisAcik");
            DropColumn("dbo.Kurumlar", "FaaliyetDurumGirisAcik");
            DropColumn("dbo.Kurumlar", "FaaliyetGirisAcik");
            DropColumn("dbo.Kurumlar", "AktifYil");
        }
    }
}
