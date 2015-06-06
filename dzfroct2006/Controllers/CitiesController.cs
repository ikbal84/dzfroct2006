using dzfroct2006.BLL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace dzfroct2006.Controllers
{
    public class CitiesController : Controller
    {
        //
        // GET: /Cities/
        
        public ActionResult Search(string term)
        {
            var citiesQuery = new CitiesQuery();
            String cyties = CitiesQuery.GetListCities(term);

            ViewBag.Cyties = cyties;
            
            return View();

        }
        

    }
}
