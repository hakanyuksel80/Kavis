using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using KavisWeb.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult FaaliyetRaporu()
        {

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            List<FaaliyetListView> model = manager.GetFaaliyetRapor();

            return View(model);
        }    

        public ActionResult BirimGosterge()
        {
            return View();
        }

        public ActionResult BirimFaaliyet()
        {
            return View();
        }

        public ActionResult Gostergeler()
        {
            return View();
        }

        public PartialViewResult UserMenu()
        {
            var kavisUser = KavisHelper.GetUser();
            return PartialView(kavisUser);
        }

    }
}