using KavisWeb.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class StratejikPlanController : Controller
    {
        private IStratejikPlanService _stratejikPlanManager;

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
    }
}