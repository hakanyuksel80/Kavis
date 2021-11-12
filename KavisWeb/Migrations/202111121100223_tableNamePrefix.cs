namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableNamePrefix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Amaclar", newName: "Kavis_Amaclar");
            RenameTable(name: "dbo.Hedefler", newName: "Kavis_Hedefler");
            RenameTable(name: "dbo.Gostergeler", newName: "Kavis_Gostergeler");
            RenameTable(name: "dbo.Stratejiler", newName: "Kavis_Stratejiler");
            RenameTable(name: "dbo.Eylemler", newName: "Kavis_Eylemler");
            RenameTable(name: "dbo.Plans", newName: "Kavis_Plans");
            RenameTable(name: "dbo.Kurumlar", newName: "Kavis_Kurumlar");
            RenameTable(name: "dbo.Birimler", newName: "Kavis_Birimler");
            RenameTable(name: "dbo.Faaliyetler", newName: "Kavis_Faaliyetler");
            RenameTable(name: "dbo.GostergeGirisleri", newName: "Kavis_GostergeGirisleri");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Kavis_GostergeGirisleri", newName: "GostergeGirisleri");
            RenameTable(name: "dbo.Kavis_Faaliyetler", newName: "Faaliyetler");
            RenameTable(name: "dbo.Kavis_Birimler", newName: "Birimler");
            RenameTable(name: "dbo.Kavis_Kurumlar", newName: "Kurumlar");
            RenameTable(name: "dbo.Kavis_Plans", newName: "Plans");
            RenameTable(name: "dbo.Kavis_Eylemler", newName: "Eylemler");
            RenameTable(name: "dbo.Kavis_Stratejiler", newName: "Stratejiler");
            RenameTable(name: "dbo.Kavis_Gostergeler", newName: "Gostergeler");
            RenameTable(name: "dbo.Kavis_Hedefler", newName: "Hedefler");
            RenameTable(name: "dbo.Kavis_Amaclar", newName: "Amaclar");
        }
    }
}
