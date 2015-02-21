using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace dzfroct2006.Controllers
{
    public class OwnerSpaceController : Controller
    {
        //
        // GET: /OwnerSpace/

        public ActionResult HotelOwnerSpace()
        {
            return View();
        }

        public ActionResult CreateHotel()
        {
            return View();
        }
    }

}
