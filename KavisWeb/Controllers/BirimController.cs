using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
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
        public ActionResult Index(int id = 0)
        {
            int birim = id;

            var stratejiler = manager.GetAllStratejiByBirim(birim);

            var faaliyetler = manager.GetAllFaaliyetByBirim(birim);

            BirimListesiYukle();

            ViewPerformansGirisModel model = new ViewPerformansGirisModel()
            {
                Stratejiler = stratejiler,
                Faaliyetler = faaliyetler,
            };

            return View(model);
        }

        public ActionResult Gosterge(int id = 0)
        {
            ViewBag.AktifYil = 2;
            
            BirimListesiYukle();

            

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

        private void BirimListesiYukle()
        {
            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var birimler = birimManager.GetAll();

            List<SelectListItem> birimSelectList = (from x in birimler select new SelectListItem { Value = x.Id.ToString(), Text = x.Baslik }).ToList();
            

            ViewBag.BirimSelectList = birimSelectList;
        }
    }
}