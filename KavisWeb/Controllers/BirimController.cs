using KavisWeb.BusinessLayer;
using KavisWeb.Enitites.DbModels;
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

        public ActionResult Gosterge(int id = 0)
        {
            ViewBag.AktifYil = 3;            

            if (id > 0)
            {
                StratejikPlan stratejikPlan = this.manager.GetAktifStratejikPlan();


                foreach (var amac in stratejikPlan.Amaclar)
                {
                    foreach (var hedef in amac.Hedefler)
                    {
                        hedef.Gostergeler = hedef.Gostergeler.Where(x => x.SorumluBirimId == id).ToList();
                    }

                    amac.Hedefler = amac.Hedefler.Where(x => x.Gostergeler.Count() > 0).ToList();
                }

                stratejikPlan.Amaclar = stratejikPlan.Amaclar.Where(x => x.Hedefler.Count() > 0).ToList();


                return View(stratejikPlan);

            }

            return View(new StratejikPlan());
        }

    }
}