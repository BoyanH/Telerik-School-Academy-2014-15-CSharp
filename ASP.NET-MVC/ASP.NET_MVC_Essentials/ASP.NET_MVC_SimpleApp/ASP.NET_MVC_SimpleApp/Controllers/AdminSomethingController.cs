using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC_SimpleApp.Controllers
{
    public class AdminSomethingController : Controller
    {
        // GET: AdminSomething
        public ActionResult Index()
        {
            return Content("You can access any controller starting with \"Admin\" from /AdminPanel! ;)");
        }
    }
}