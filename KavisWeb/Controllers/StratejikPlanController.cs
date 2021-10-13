using KavisWeb.BusinessLayer;
using KavisWeb.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class StratejikPlanController : Controller
    {
        private StratejikPlanManager2 _stratejikPlanManager;

        public StratejikPlanController()
        {
            _stratejikPlanManager = new StratejikPlanManager2();            
        }

        // GET: StratejikPlan
        public ActionResult Index()
        {
            var list = _stratejikPlanManager.GetViewList();
            return View(list);
        }

        public ActionResult Eylemler()
        {
            return View();
        }

        public ActionResult Edit()
        {
            return View();
        }

        
        public JsonResult KurumlarListe()
        {

            KurumManager kurumManager = new KurumManager();

            var liste = kurumManager.GetList();

           var t =  from x in liste
                   select new ListViewItem { Id = x.Id, Adi = x.Adi };

            return Json(t.ToList(), JsonRequestBehavior.AllowGet);

        }
    }
}