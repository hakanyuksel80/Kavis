namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Birim : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Faaliyetler", "BirimAdi", c => c.String());
            AlterColumn("dbo.Faaliyetler", "Birim", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faaliyetler", "Birim", c => c.String());
            DropColumn("dbo.Faaliyetler", "BirimAdi");
        }
    }
}
