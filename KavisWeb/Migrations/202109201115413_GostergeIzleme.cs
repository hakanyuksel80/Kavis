namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GostergeIzleme : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gostergeler", "Izleme", c => c.String());
            AddColumn("dbo.Gostergeler", "Rapor", c => c.String());
            AddColumn("dbo.Gostergeler", "SorumluBirimId", c => c.Int(nullable: false));
            AddColumn("dbo.Gostergeler", "SorumluBirim", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Gostergeler", "SorumluBirim");
            DropColumn("dbo.Gostergeler", "SorumluBirimId");
            DropColumn("dbo.Gostergeler", "Rapor");
            DropColumn("dbo.Gostergeler", "Izleme");
        }
    }
}
