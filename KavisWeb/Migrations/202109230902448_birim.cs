namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birim : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Birimler",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BurbisId = c.Int(nullable: false),
                        Kodu = c.String(),
                        Baslik = c.String(),
                    })
                .PrimaryKey(t => t.Id);

            
            
        }
        
        
        public override void Down()
        {
            DropTable("dbo.Birimler");
        }

        
    }
}
