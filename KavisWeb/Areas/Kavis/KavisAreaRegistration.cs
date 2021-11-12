using System.Web.Mvc;

namespace KavisWeb.Areas.Kavis
{
    public class KavisAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Kavis";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Kavis_default",
                "Kavis/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}