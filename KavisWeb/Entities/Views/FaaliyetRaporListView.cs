using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Views
{
    public class FaaliyetRaporListView
    {

        public int Id { get; set; }

        public string EylemAdi { get; set; }

        public string FaaliyetAdi { get; set; }

        public string Birim { get; set; }

        public string Tarih { get; set; }

        public string Gerceklesme { get; set; }

        public string Sonuc { get; set; }

        public string Durum { get; set; }
        
    }
}