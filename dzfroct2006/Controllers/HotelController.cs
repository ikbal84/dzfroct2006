using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dzfroct2006.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/

        public ActionResult Hotel()
        {
            ViewBag.dateDebut = new DateTime(2014, 12, 26).Date;
            ViewBag.dateFin = new DateTime(2015, 12, 26).Date;
            ViewBag.ville = "Oran";


            HotelImages hotelImages = new HotelImages { IdImage = 11, Name = "hotelTest1", FilePath = "../Images/HotelsImages/HotelTest/hotelTest2.png" };

            List<HotelImages> listHotelImages = new List<HotelImages>();
            listHotelImages.Add(hotelImages);

            HotelRooms room1 = new HotelRooms { RoomType = "Double", Description = "Chambre double Luxe", NbRooms = 5, NbPersonnes = 2, Price = "5000DA" };
            List<HotelRooms> listRoom = new List<HotelRooms>();
            listRoom.Add(room1);
            var hotel = new Hotels() { Name = "TestHotel", Description = "Un simple hotel de test", PhoneNumber1 = "002130000001", FaxNumber1 = "0021321659878", Address = "01 rue des tests oran", HotelImages = listHotelImages, Rooms = listRoom };

            return View(hotel);
        }

        //
        // GET: /Hotel/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Hotel/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Hotel/Create

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
        // GET: /Hotel/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Hotel/Edit/5

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
        // GET: /Hotel/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Hotel/Delete/5

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
