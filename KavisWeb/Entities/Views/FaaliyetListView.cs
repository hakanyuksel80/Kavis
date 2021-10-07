using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Views
{
    public class FaaliyetListView
    {
        public int Id { get; set; }

        public string EylemAdi { get; set; }

        public string FaaliyetAdi { get; set; }

        public string Birim { get; set; }        

        public DateTime? Baslama { get;  set; }

        public DateTime? Bitis { get;  set; }

        
        public string Tarihler
        {
            get
            {
                string a = "";

                if (this.Baslama != null)
                {
                    a = Baslama.Value.ToShortDateString();
                }

                if (this.Bitis != null)
                {
                    a += " - " + Bitis.Value.ToShortDateString();
                }

                return a;
            }

        }

        public string Gerceklesme { get; set; }
        public string Sonuc { get; internal set; }
    }
}