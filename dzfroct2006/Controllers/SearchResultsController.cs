using dzfroct2006.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dzfroct2006.Controllers
{
    public class SearchResultsController : Controller
    {
        //
        // GET: /SearchResults/

        public ActionResult HotelsSearchResult()
        {
            
            if (Session["Query"] != null)
            {
                //make SearchQuery as singleton!!!

                var SearchQuery = (HotelsQuery)Session["Query"];

                ViewBag.dateDebut = SearchQuery.StartDate;
                ViewBag.dateFin = SearchQuery.EndDate;
                ViewBag.ville = SearchQuery.City;
 
                return View(SearchQuery.getHotelsFromHome());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult HotelsSearchResult(FormCollection Filters)
        {
            var SearchQuery = (HotelsQuery)Session["Query"];
           // SearchQuery.Features = new List<SearchFeatures>();

            if (Filters.Count > 0)
            {
                foreach (var feature in SearchQuery.Features)
                {
                    foreach (var key in Filters.AllKeys)
                    {
                        if (feature.SearchFeatureName == key)
                        {
                            feature.SearchFeatureValue = "checked";
                            break;
                        }
                        else
                        {
                            feature.SearchFeatureValue = "";
                        }
                    }
                }
            }
            else
            {
                SearchQuery.IntiFeatures();
            }

            Session["Query"] = SearchQuery.makeNewSearch();
            return View((HotelsQuery)Session["Query"]);
        }

    }
}
