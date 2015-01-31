using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.Mvc;
using dzfroct2006.DAL;
using dzfroct2006.Models;
using dzfroct2006.BLL;
using System.Web.Routing;

namespace dzfroct2006.Controllers
{
    
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(FormCollection FormValues)
        {
            DateTime StartDate;
            DateTime EndDate;

            String City = HttpUtility.HtmlDecode(FormValues["City"]);
            bool isStartDateParsed = DateTime.TryParse(HttpUtility.HtmlDecode(FormValues["StartDate"]), out StartDate);
            bool isEndDateParsed = DateTime.TryParse(HttpUtility.HtmlDecode(FormValues["EndDate"]), out EndDate);

            StartDate = isStartDateParsed ? StartDate : DateTime.Now.Date;
            EndDate = isEndDateParsed ? EndDate : DateTime.Now.AddDays(7).Date;

            int NbPersonnes= Int32.Parse(HttpUtility.HtmlDecode(FormValues["NbPersonnes"]));
            int NbRooms = Int32.Parse(HttpUtility.HtmlDecode(FormValues["NbRooms"]));

                        
            HotelsQuery query = new HotelsQuery() { 
                                City = City, 
                                StartDate = StartDate, 
                                EndDate = EndDate, 
                                NbPersonnes = NbPersonnes,
                                NbRooms = NbRooms 
                            };
            Session["Query"] = query;

            return RedirectToAction("HotelsSearchResult", "SearchResults");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ChangeLanguage(string culture)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;

            Session["lang"] = culture;
            HttpCookie languageCookie = new HttpCookie("languageCookie");
            languageCookie["lang"] = culture;
            Response.Cookies.Add(languageCookie);
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}
