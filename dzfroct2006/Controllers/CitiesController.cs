using dzfroct2006.BLL;
using dzfroct2006.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dzfroct2006.Controllers
{
    public class CitiesController : Controller
    {
        //
        // GET: /Cities/

        public ActionResult search(string textSerched)
        {
            Dictionary<string, string> udemy = new Dictionary<string, string>();
            var citiesQuery = new CitiesQuery();
            List<string> cities = citiesQuery.getListCities(textSerched, null);

            string js = JsonConvert.SerializeObject(cities);
            return Json(js, JsonRequestBehavior.AllowGet);      
          
        }

        //
        // GET: /Cities/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Cities/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cities/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cities/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Cities/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Cities/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Cities/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
