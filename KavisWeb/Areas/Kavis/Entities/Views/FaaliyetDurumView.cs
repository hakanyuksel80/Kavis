using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Views
{
    public class FaaliyetDurumView
    {
        public int Id { get; set; }

        public string EylemAdi { get; set; }

        public string FaaliyetAdi { get; set; }

        public string Gerceklesme { get; set; }

        public DateTime? Baslama { get; set; }

        public DateTime? Bitis { get; set; }

        public string Sonuc { get; set; }

        public string Durum { get; set; }

    }
}