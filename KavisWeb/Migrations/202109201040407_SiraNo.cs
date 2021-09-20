namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SiraNo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Amaclar", "SiraNo", c => c.Int(nullable: false));
            AddColumn("dbo.Hedefler", "SiraNo", c => c.Int(nullable: false));
            AddColumn("dbo.Gostergeler", "SiraNo", c => c.Int(nullable: false));
            AddColumn("dbo.Stratejiler", "SiraNo", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stratejiler", "SiraNo");
            DropColumn("dbo.Gostergeler", "SiraNo");
            DropColumn("dbo.Hedefler", "SiraNo");
            DropColumn("dbo.Amaclar", "SiraNo");
        }
    }
}
