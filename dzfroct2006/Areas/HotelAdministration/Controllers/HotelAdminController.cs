using Hotels.Data.Model;
using Hotels.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace dzfroct2006.Areas.HotelAdministration.Controllers
{
    
    public class HotelAdminController : Controller
    {
        //
        // GET: /HotelAdministration/HotelAdmin/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Hotel CreatedHotel)
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
        public ActionResult CreateRooms(HotelRoom room, String hotelId, String isLast)
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
            catch (Exception)
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
        public ActionResult CreateImage(HotelImage ImageObject, String hotelId, HttpPostedFileBase Image)
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
            catch (Exception)
            {
                return View();
            }
        }
    }
}
