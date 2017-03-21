using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_SimpleApp.Areas.RainbowUnicorns.Controllers
{
    public class MagicalController : Controller
    {
        // GET: RainbowUnicorns/Magical
        public ActionResult Index()
        {
            return View();
        }

        // GET: RainbowUnicorns/Magical/ActivateSpecialPower
        public ActionResult ActivateSpecialPower()
        {
            return View();
        }
    }
}