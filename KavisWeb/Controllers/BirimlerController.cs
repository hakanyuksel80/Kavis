using KavisWeb.BusinessLayer;
using KavisWeb.DataLayer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class BirimlerController : Controller
    {
        // GET: Birimler
        public ActionResult Index(int id = 0)
        {
            BirimManager manager = new BirimManager(new EfBirimDal());

            KurumManager kurumManager = new KurumManager();

            if (id > 0)
            {
                var kurum = kurumManager.Get(id);

                if (kurum != null)
                {
                    var birimler = manager.GetAll(id);

                    ViewBag.KurumAdi = kurum.Adi;
                    ViewBag.KurumId = kurum.Id;

                    return View(birimler);
                }

            }

            return View();

        }
    }
}