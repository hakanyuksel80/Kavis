using KavisWeb.Entities.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Views
{
    public class ViewPerformansGirisModel
    {
        public List<Strateji> Stratejiler { get; set; }

        public List<FaaliyetListView> Faaliyetler { get; set; }

        public Birim Birim { get; set; }

        public ViewPerformansGirisModel()
        {
            Stratejiler = new List<Strateji>();
            Faaliyetler = new List<FaaliyetListView>();

            Birim = new Birim() { Kurum = new Kurum() };
        }
    }
}