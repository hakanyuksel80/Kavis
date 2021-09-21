using KavisWeb.Enitites.DbModels;
using KavisWeb.Enitites.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Models
{
    public class ViewPerformansGirisModel
    {
        public List<Strateji> Stratejiler { get; internal set; }

        public List<FaaliyetListView> Faaliyetler { get; internal set; }
    }
}