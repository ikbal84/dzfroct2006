using System.Web.Mvc;

namespace dzfroct2006.Areas.HotelAdministration
{
    public class HotelAdministrationAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HotelAdministration";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HotelAdministration_default",
                "HotelAdministration/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
