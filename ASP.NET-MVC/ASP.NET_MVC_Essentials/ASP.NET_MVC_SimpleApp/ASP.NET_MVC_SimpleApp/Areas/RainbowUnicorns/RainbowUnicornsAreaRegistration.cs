using System.Web.Mvc;

namespace ASP.NET_MVC_SimpleApp.Areas.RainbowUnicorns
{
    public class RainbowUnicornsAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RainbowUnicorns";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RainbowUnicorns_default",
                "RainbowUnicorns/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}