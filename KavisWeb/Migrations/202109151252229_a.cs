namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Amaclar", "StratejikPlanId", "dbo.Plans");
            DropForeignKey("dbo.Hedefler", "Amac_Id", "dbo.Amaclar");
            DropIndex("dbo.Amaclar", new[] { "StratejikPlanId" });
            DropColumn("dbo.Amaclar", "Id");
            RenameColumn(table: "dbo.Amaclar", name: "StratejikPlanId", newName: "Id");
            DropPrimaryKey("dbo.Amaclar");
            AlterColumn("dbo.Amaclar", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Amaclar", "Id");
            CreateIndex("dbo.Amaclar", "Id");
            AddForeignKey("dbo.Amaclar", "Id", "dbo.Plans", "Id");
            AddForeignKey("dbo.Hedefler", "Amac_Id", "dbo.Amaclar", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Hedefler", "Amac_Id", "dbo.Amaclar");
            DropForeignKey("dbo.Amaclar", "Id", "dbo.Plans");
            DropIndex("dbo.Amaclar", new[] { "Id" });
            DropPrimaryKey("dbo.Amaclar");
            AlterColumn("dbo.Amaclar", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Amaclar", "Id");
            RenameColumn(table: "dbo.Amaclar", name: "Id", newName: "StratejikPlanId");
            AddColumn("dbo.Amaclar", "Id", c => c.Int(nullable: false, identity: true));
            CreateIndex("dbo.Amaclar", "StratejikPlanId");
            AddForeignKey("dbo.Hedefler", "Amac_Id", "dbo.Amaclar", "Id");
            AddForeignKey("dbo.Amaclar", "StratejikPlanId", "dbo.Plans", "Id", cascadeDelete: true);
        }
    }
}
