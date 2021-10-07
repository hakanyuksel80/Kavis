using KavisWeb.BusinessLayer;
using KavisWeb.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class PerformansProgramiController : Controller
    {

        
        public PerformansProgramiController()
        {

        }
        // GET: PerformansProgrami
        public ActionResult Index()
        {

            StratejikPlanManager2 manager = new StratejikPlanManager2();

            List<FaaliyetListView> faaliyetler = manager.GetAllFaaliyet();

            return View(faaliyetler);
        }
    }
}