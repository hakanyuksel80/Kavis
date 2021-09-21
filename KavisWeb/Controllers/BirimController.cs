using KavisWeb.BusinessLayer;
using KavisWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class BirimController : Controller
    {

        IStratejikPlanService manager;

        string birim = "";

        public BirimController()
        {
            this.manager = new StratejikPlanManager2();
        }

        // GET: Birim
        public ActionResult Index()
        {
            var stratejiler = manager.GetAllStratejiByBirim(birim);

            var faaliyetler = manager.GetAllFaaliyetByBirim(birim);

            ViewPerformansGirisModel model = new ViewPerformansGirisModel()
            {
                Stratejiler = stratejiler,
                Faaliyetler = faaliyetler,
            };


            return View(model);
        }

        public ActionResult Gosterge()
        {
            return View();
        }
        
    }
}