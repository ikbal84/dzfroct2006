using Hotels.Business;
using Hotels.Data.Services;
using Hotels.Data.Model;
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

        public ActionResult Hotel()
        {
            var SearchQuery = (HotelsQuery)Session["Query"];
            
            ViewBag.dateDebut = new DateTime(2014, 12, 26).Date;
            ViewBag.dateFin = new DateTime(2015, 12, 26).Date;
            ViewBag.ville = "Oran";
            string nameHotel = "Hotel Anissov";
            string pathHotelName = nameHotel.Replace(" ", "");
            HotelImage hotelImages1 = new HotelImage { IdImage = 11, Description = "Hall de l'hotel", Name = "Hall", FilePath = "../../Images/HotelsImages/" + pathHotelName + "/img1.jpg" };
            HotelImage hotelImages2 = new HotelImage { IdImage = 12, Description = "Chambre double Luxe", Name = "Hall", FilePath = "../../Images/HotelsImages/" + pathHotelName + "/img2.jpg" };
            HotelImage hotelImages3 = new HotelImage { IdImage = 13, Description = "Restaurant", Name = "Hall", FilePath = "../../Images/HotelsImages/" + pathHotelName + "/img3.jpg" };
            
            List<HotelImage> listHotelImages = new List<HotelImage>();
            listHotelImages.Add(hotelImages1);
            listHotelImages.Add(hotelImages2);
            listHotelImages.Add(hotelImages3);

            HotelRoom room1 = new HotelRoom { RoomType = "Double", Description = "Chambre double Luxe", NbRooms = 5, NbPersonnes = 2, Price = "5000DA" };
            HotelRoom room2 = new HotelRoom { RoomType = "Single", Description = "Chambre single", NbRooms = 3, NbPersonnes = 1, Price = "3000DA" };
            
            List<HotelRoom> listRoom = new List<HotelRoom>();
            listRoom.Add(room1);
            listRoom.Add(room2);

            var hotel = new Hotel()
            { 
                                       Name = nameHotel, 
                                       Description = "Un simple hotel de test", 
                                       PhoneNumber1 = "002130000001", 
                                       FaxNumber1 = "0021321659878", 
                                       Address = "01 rue des tests oran", 
                                       HotelImages = listHotelImages, 
                                       Rooms = listRoom,
                                       Email1 = "hotel.dz@gmail.com"
                                    };

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


        
    }
}
