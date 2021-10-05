using KavisWeb.BusinessLayer;
using KavisWeb.Enitites.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class KurumlarController : Controller
    {
        // GET: Kurum
        public ActionResult Index()
        {
            KurumManager manager = new KurumManager();

            var kurumlar = manager.GetList();

            return View(kurumlar);
        }


        public JsonResult StratejikPlanlar(int id)
        {

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            var liste = from x in manager.GetKurumSPList(id)
                        select new ListViewItem { Id = x.Id, Adi = x.Baslangic + "-" + x.Bitis };

            return Json(liste, JsonRequestBehavior.AllowGet);

        }

    }
}