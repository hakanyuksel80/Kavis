namespace KavisWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableNameBurbis : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Kavis_Amaclar", newName: "burbis_11_Amaclar");
            RenameTable(name: "dbo.Kavis_Hedefler", newName: "burbis_11_Hedefler");
            RenameTable(name: "dbo.Kavis_Gostergeler", newName: "burbis_11_Gostergeler");
            RenameTable(name: "dbo.Kavis_Stratejiler", newName: "burbis_11_Stratejiler");
            RenameTable(name: "dbo.Kavis_Eylemler", newName: "burbis_11_Eylemler");
            RenameTable(name: "dbo.Kavis_Plans", newName: "burbis_11_Plans");
            RenameTable(name: "dbo.Kavis_Kurumlar", newName: "burbis_11_Kurumlar");
            RenameTable(name: "dbo.Kavis_Birimler", newName: "burbis_11_Birimler");
            RenameTable(name: "dbo.Kavis_Faaliyetler", newName: "burbis_11_Faaliyetler");
            RenameTable(name: "dbo.Kavis_GostergeGirisleri", newName: "burbis_11_GostergeGirisleri");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.burbis_11_GostergeGirisleri", newName: "Kavis_GostergeGirisleri");
            RenameTable(name: "dbo.burbis_11_Faaliyetler", newName: "Kavis_Faaliyetler");
            RenameTable(name: "dbo.burbis_11_Birimler", newName: "Kavis_Birimler");
            RenameTable(name: "dbo.burbis_11_Kurumlar", newName: "Kavis_Kurumlar");
            RenameTable(name: "dbo.burbis_11_Plans", newName: "Kavis_Plans");
            RenameTable(name: "dbo.burbis_11_Eylemler", newName: "Kavis_Eylemler");
            RenameTable(name: "dbo.burbis_11_Stratejiler", newName: "Kavis_Stratejiler");
            RenameTable(name: "dbo.burbis_11_Gostergeler", newName: "Kavis_Gostergeler");
            RenameTable(name: "dbo.burbis_11_Hedefler", newName: "Kavis_Hedefler");
            RenameTable(name: "dbo.burbis_11_Amaclar", newName: "Kavis_Amaclar");
        }
    }
}
