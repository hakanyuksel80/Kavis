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
    public class PerformansProgramiController : Controller
    {


        public PerformansProgramiController()
        {

        }
        // GET: PerformansProgrami
        public ActionResult Index(int id = 0, int yil = 0)
        {
            StratejikPlanManager2 manager = new StratejikPlanManager2();

            List<FaaliyetListView> faaliyetler = null;

            if (id > 0)
                faaliyetler = manager.GetAllFaaliyetByBirim(id, yil);
            else
                faaliyetler = manager.GetAllFaaliyet(yil);
            
            BirimManager birimManager = new BirimManager(new EfBirimDal());

            var sp = manager.GetAktifStratejikPlan(KavisHelper.GetUser().KurumId);

            if (sp != null)
            {
                KavisHelper.YilListesiYukle(this,sp);
            }

            KavisHelper.BirimListesiYukle(this, KavisHelper.GetUser().KurumId);

            return View(faaliyetler);
        }

        
    }
}