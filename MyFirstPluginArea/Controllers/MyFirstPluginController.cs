using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;


namespace MyFirstPluginArea.Controllers
{
    public class MyFirstPluginController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
