using KavisWeb.BusinessLayer;
using KavisWeb.Enitites.Views;
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

        public ActionResult Ayarlar()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult FaaliyetRaporu()
        {

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            List<FaaliyetRaporListView> model = manager.GetFaaliyetRapor();

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

    }
}