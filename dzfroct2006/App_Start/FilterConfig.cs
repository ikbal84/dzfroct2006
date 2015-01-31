using System.Web;
using System.Web.Mvc;

namespace dzfroct2006
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LanguageFilter());
        }
    }
}