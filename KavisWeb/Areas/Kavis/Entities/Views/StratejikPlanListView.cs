using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.Views
{
    /// <summary>
    /// Stratejik Plan Listeleme de kullanılır
    /// </summary>
    public class StratejikPlanListView
    {
        public int Id { get; set; }

        public string Donem { get; set; }

        public string Kurum { get; set; }

        public string Turu { get; set; }

    }
}