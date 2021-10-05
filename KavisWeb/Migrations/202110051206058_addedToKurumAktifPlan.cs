namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedToKurumAktifPlan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Kurumlar", "AktifPlanId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Kurumlar", "AktifPlanId");
        }
    }
}
