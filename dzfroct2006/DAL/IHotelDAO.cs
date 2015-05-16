using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dzfroct2006.Models;

namespace dzfroct2006.DAL
{
    interface IHotelDAO
    {
        bool CreateHotel(Hotels hotel);
        bool CreateRoom(String hotelId, HotelRooms room);
        bool CreateImage(String hotelId, HotelImages Image);

    }
}
