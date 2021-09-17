using KavisWeb.DataLayer;
using KavisWeb.Enitites.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class DenemeController : Controller
    {
        // GET: Deneme
        public ActionResult Index()
        {

            StrategyDBContext context = new StrategyDBContext();

            StratejikPlan plan = new StratejikPlan() { Id = 1, KurumAdi = "Deneme" } ;

            context.StratejikPlanlar.Add(plan);

            context.SaveChanges();


            //var plan = context.StratejikPlanes.FirstOrDefault();

            //plan.Items = context.StrategyItems.Where(x=>x.)

            //var amac = context.StrategyItems.Where(x=>x.ItemType == StrategyItemType.Amac).FirstOrDefault();

            //amac.Items = new List<StrategyItem>();

            //amac.Items.Add(new StrategyItem
            //{
            //    Code = "1.1",
            //    ItemType = StrategyItemType.Hedef,
            //    ParentId = amac.Id,
            //    Title = "HEDEFİM 1.1",
            //    Items = new List<StrategyItem>()
            //    {
            //        new GostergeBilgileri
            //        {
            //            Code = "1.1.1",ItemType = StrategyItemType.Gosterge,
            //            Title = "PERFORMANS GÖSTERGESİ 1.1.1",
            //            Baslangic = "5",
            //            HedefeEtkisi = "%4",
            //            Yil1 ="6",
            //            Yil2 ="7",
            //            Yil3 ="8",
            //            Yil4 ="9",
            //            Yil5 ="10",
            //        }
            //    }
            //});

            //context.SaveChanges();

            return View();
        }
    }
}