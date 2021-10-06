namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimeNull : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Faaliyetler", "Baslama", c => c.DateTime());
            AlterColumn("dbo.Faaliyetler", "Bitis", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Faaliyetler", "Bitis", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Faaliyetler", "Baslama", c => c.DateTime(nullable: false));
        }
    }
}
