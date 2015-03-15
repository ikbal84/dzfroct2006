using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace dzfroct2006.Controllers
{
    public class HotelController : Controller
    {
        //
        // GET: /Hotel/

        public ActionResult Hotel(String id)
        {
            ViewBag.dateDebut = new DateTime(2014, 12, 26).Date;
            ViewBag.dateFin = new DateTime(2015, 12, 26).Date;
            ViewBag.ville = "Oran";
            var hotelDao = new HotelDAO();
            Hotels hotel = hotelDao.SelectHotls(Int32.Parse(id));
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

  /// <summary>
  /// Step 1 of creation
  /// </summary>
  /// <param name="CreatedHotel"></param>
  /// <returns></returns>

        [HttpPost]
        public ActionResult Create(Hotels CreatedHotel)
        {
            try
            {
                var HotelDAO = new HotelDAO();

                if (HotelDAO.CreateHotel(CreatedHotel))
                {
                    return RedirectToAction("CreateRooms", new { CreatedHotel.HotelID });
                }
                else
                {
                    //do someting..
                    return View();
                }

            }
            catch
            {
                return View();
            }
        }

        public ActionResult CreateRooms(String HotelID)
        {
            ViewBag.hotelId = HotelID;
            return View();
        }

        [HttpPost]
        public ActionResult CreateRooms(HotelRooms room, String hotelId, String isLast)
        {
            try
            {
                var HotelDAO = new HotelDAO();

                HotelDAO.CreateRoom(hotelId, room);
                
                if (isLast.Equals("0"))
                    return RedirectToAction("CreateRooms", new { hotelId });
                else 
                    return RedirectToAction("CreateImage", new { hotelId });
            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult CreateImage(String HotelID)
        {
            ViewBag.hotelId = HotelID;
            return View();
        }
        
        [HttpPost]
        public ActionResult CreateImage(HotelImages ImageObject, String hotelId, HttpPostedFileBase Image)
        {
            try
            {
                //Getting the file
                string pic = System.IO.Path.GetFileName(ImageObject.Name + "_" + hotelId);
                ImageObject.FilePath = System.IO.Path.Combine(
                                       Server.MapPath("~/Images"), pic);
                // file is uploaded
                Image.SaveAs(ImageObject.FilePath);

                //saving the file on the disk

                var HotelDAO = new HotelDAO();
                HotelDAO.CreateImage(hotelId, ImageObject);

                return RedirectToAction("CreateImage", new { hotelId });
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        
    }
}
