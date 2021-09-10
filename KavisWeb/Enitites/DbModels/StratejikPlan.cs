using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Enitites.DbModels
{
    public class StratejikPlan
    {
        public int Id { get; set; }

        public string Donem { get; set; }

        public List<PlanItem> Items { get; set; }

    }
}