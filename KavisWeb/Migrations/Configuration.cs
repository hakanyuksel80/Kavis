namespace KavisWeb.Migrations
{
    using KavisWeb.Enitites.DbModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KavisWeb.DataLayer.StrategyDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "KavisWeb.DataLayer.StrategyDBContext";
        }

        protected override void Seed(KavisWeb.DataLayer.StrategyDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //



            context.Birimler.AddOrUpdate( 
                new Birim { Id = 1, BurbisId = 1, Baslik = "Arge" },
                new Birim { Id = 2, BurbisId = 2, Baslik = "Arþiv" },
                new Birim { Id = 3, BurbisId = 3, Baslik = "Avukatlar" },
                new Birim { Id = 4, BurbisId = 4, Baslik = "Basýn ve Halkla Ýliþkiler" },
                new Birim { Id = 5, BurbisId = 5, Baslik = "Bilgi Ýþlem ve Eðitim Teknolojileri" },
                new Birim { Id = 7, BurbisId = 7, Baslik = "Danýþma ve Güvenlik" },
                new Birim { Id = 8, BurbisId = 8, Baslik = "Denklik" },
                new Birim { Id = 9, BurbisId = 9, Baslik = "DEPO (Destek Hizmetleri)" },
                new Birim { Id = 10, BurbisId = 10, Baslik = "Destek Hizmetleri (Mutemetlik)" },
                new Birim { Id = 11, BurbisId = 11, Baslik = "Destek Hizmetleri(Bütçe-Donatým-Taþýnýr)" },
                new Birim { Id = 12, BurbisId = 12, Baslik = "Din Öðretimi" },
                new Birim { Id = 13, BurbisId = 15, Baslik = "Evrak Kayýt" },
                new Birim { Id = 14, BurbisId = 16, Baslik = "Genel" },
                new Birim { Id = 15, BurbisId = 17, Baslik = "Hayat Boyu Öðrenme" },
                new Birim { Id = 16, BurbisId = 18, Baslik = "Hukuk Hizmetleri" },
                new Birim { Id = 17, BurbisId = 19, Baslik = "Ýl Enerji Yönetimi" },
                new Birim { Id = 18, BurbisId = 20, Baslik = "Ýnceleme ve Rehberlik" },
                new Birim { Id = 19, BurbisId = 21, Baslik = "Ýnþaat Emlak Hizmetleri(Emlak Büro)" },
                new Birim { Id = 20, BurbisId = 22, Baslik = "Ýnþaat Emlak Hizmetleri(Ýnþaat Büro)" },
                new Birim { Id = 21, BurbisId = 23, Baslik = "Ýnþaat Emlak Hizmetleri(Teknik Büro)" },
                new Birim { Id = 22, BurbisId = 24, Baslik = "Ýþ Güvenliði" },
                new Birim { Id = 23, BurbisId = 25, Baslik = "Kat Görevlisi" },
                new Birim { Id = 24, BurbisId = 26, Baslik = "Mesleki ve Teknik Eðitim" },
                new Birim { Id = 25, BurbisId = 28, Baslik = "Orta Öðretim" },
                new Birim { Id = 26, BurbisId = 29, Baslik = "Öðretmen Atama" },
                new Birim { Id = 27, BurbisId = 30, Baslik = "Öðretmen Yetiþtirme (Aday Performans)" },
                new Birim { Id = 28, BurbisId = 31, Baslik = "Öðretmen Yetiþtirme (Hizmetiçi)" },
                new Birim { Id = 29, BurbisId = 33, Baslik = "Özel Büro" },
                new Birim { Id = 30, BurbisId = 34, Baslik = "Özel Eðitim ve Rehberlik" },
                new Birim { Id = 31, BurbisId = 35, Baslik = "Özel Kalem" },
                new Birim { Id = 32, BurbisId = 38, Baslik = "Özel Öðretim" },
                new Birim { Id = 33, BurbisId = 39, Baslik = "Özlük-Terfi-Emeklilik" },
                new Birim { Id = 34, BurbisId = 40, Baslik = "Pasaport" },
                new Birim { Id = 35, BurbisId = 41, Baslik = "Personel Atama" },
                new Birim { Id = 36, BurbisId = 43, Baslik = "Santral" },
                new Birim { Id = 37, BurbisId = 44, Baslik = "Sýnav Hizmetleri" },
                new Birim { Id = 38, BurbisId = 45, Baslik = "Sivil Savunma" },
                new Birim { Id = 39, BurbisId = 46, Baslik = "Strateji Geliþtirme" },
                new Birim { Id = 40, BurbisId = 47, Baslik = "Þoförler" },
                new Birim { Id = 41, BurbisId = 48, Baslik = "Taþýmalý Eðitim" },
                new Birim { Id = 42, BurbisId = 49, Baslik = "Teknik Büro (Destek Hizmetleri)" },
                new Birim { Id = 43, BurbisId = 50, Baslik = "Temel Eðitim(Anaokulu-Ýlkokul)" },
                new Birim { Id = 44, BurbisId = 51, Baslik = "Temel Eðitim(Ortaokul)" },
                new Birim { Id = 45, BurbisId = 52, Baslik = "Tesis Müdürlüðü" },
                new Birim { Id = 46, BurbisId = 54, Baslik = "Yemekhane" },
                new Birim { Id = 47, BurbisId = 55, Baslik = "Yönetici Atama" }

                );
        }
    }
}
