namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class GostergeBirimIdString : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gostergeler", "SorumluBirimId");
            AddColumn("dbo.Gostergeler", "SorumluBirimId", c => c.String(nullable: false));//Change by Hakan YÜKSEL

            //AlterColumn("dbo.Gostergeler", "SorumluBirimId", c => c.String());
        }

        public override void Down()
        {
            AlterColumn("dbo.Gostergeler", "SorumluBirimId", c => c.Int(nullable: false));
        }
    }
}
