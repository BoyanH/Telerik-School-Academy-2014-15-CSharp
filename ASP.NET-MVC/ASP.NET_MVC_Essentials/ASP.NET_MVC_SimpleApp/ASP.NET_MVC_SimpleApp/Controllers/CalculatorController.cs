namespace ASP.NET_MVC_SimpleApp.Controllers
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using ASP.NET_MVC_SimpleApp.Models;

    public class CalculatorController : Controller
    {

        // POST: Calculator
        [HttpPost]
        public ActionResult Index(BitCalculator viewModel)
        {

            viewModel.CalculateConversions();

            return View(viewModel);
        }
        
        // GET: Calculator
        public ActionResult Index()
        {

            var viewModel = new BitCalculator();

            return View(viewModel);
        }
    }
}