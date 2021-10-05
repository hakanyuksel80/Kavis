using KavisWeb.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Controllers
{
    public class KurumlarController : Controller
    {
        // GET: Kurum
        public ActionResult Index()
        {
            KurumManager manager = new KurumManager();

            var kurumlar = manager.GetList();
            
            return View(kurumlar);
        }     

    }
}