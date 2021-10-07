using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KavisWeb.Entities.DbModels
{
    public class PlanItem
    {
        public int Id { get; set; }

        public int SiraNo { get; set; }

        public string Baslik { get; set; }

        public string No { get; set; }

        public string State { get; set; }

        public int ParentId { get; set; }

        public string Birim { get; set; }

    }

    public class ParentPlanItem : PlanItem
    {
        public List<ParentPlanItem> Items { get; set; }
    }

    public class StratejikPlanItem : PlanItem
    {
        public int DonemBaslangici { get; set; }

        public string SPTuru { get; set; }

        public List<AmacItem> Amaclar { get; set; }        
    }

    public class AmacItem : PlanItem
    {
        public List<HedefItem> Hedefler { get; set; }
    }

    public class HedefItem : PlanItem
    {
        public List<PlanItem> Stratejiler { get; set; }

        public List<GostergeItem> Gostergeler { get; set; }
    }

    public class GostergeItem : PlanItem
    {
        public string HedefeEtkisi { get; set; }

        public string Baslangic { get; set; }

        public string Yil1 { get; set; }

        public string Yil2 { get; set; }

        public string Yil3 { get; set; }

        public string Yil4 { get; set; }

        public string Yil5 { get; set; }
    }
}