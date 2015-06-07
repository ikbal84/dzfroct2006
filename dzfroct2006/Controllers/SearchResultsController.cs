using Hotels.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
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
                ViewBag.ville = SearchQuery.Town + ", " + SearchQuery.Wilaya;
 
                return View(SearchQuery.GetHotelsFromHome());
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

            Session["Query"] = SearchQuery.MakeNewSearch();
            return View((HotelsQuery)Session["Query"]);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SortHotelsSearchResult(FormCollection SortQueryForm)
        {
            var SearchQuery = (HotelsQuery)Session["Query"];

            if (SortQueryForm.Count > 0)
            {
                SearchQuery.SortProperty = SortQueryForm["SortProperty"];
                SearchQuery.SortType = SortQueryForm["SortType"];
            }

            Session["Query"] = SearchQuery.SortResults();
            
            
            return View("HotelsSearchResult",(HotelsQuery)Session["Query"]);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageNumber">If -1 thengo to last page</param>
        /// <returns></returns>
        public ActionResult GoToPage(int pageNumber)
        {
            var SearchQuery = (HotelsQuery)Session["Query"];
            int pageSize = Int32.Parse(WebConfigurationManager.AppSettings["PageSize"].ToString());
            int TargetPage = (pageNumber == -1) ?
                                (Int32)Math.Ceiling((double)SearchQuery.TotalResultCount / pageSize) 
                                : pageNumber;

            Session["Query"] = SearchQuery.GetPage(TargetPage);

            return View("HotelsSearchResult", (HotelsQuery)Session["Query"]);
        }

    }
}
