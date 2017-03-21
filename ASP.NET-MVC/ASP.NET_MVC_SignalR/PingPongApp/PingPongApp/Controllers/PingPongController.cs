namespace PingPongApp.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class PingPongController : Controller
    {
        // GET: PingPong
        public ActionResult Index()
        {
            return View();
        }
    }
}