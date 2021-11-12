using KavisWeb.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KavisWeb.Areas.Kavis.Controllers
{
    public abstract class KavisBaseController : Controller
    {
        public PartialViewResult UserMenu()
        {
            var kavisUser = KavisHelper.GetUser();

            return PartialView(kavisUser);
        }
    }
}