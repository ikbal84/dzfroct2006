using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotels.Data.Model;

namespace Hotels.Data.Services
{
    interface IHotelDAO
    {
        bool CreateHotel(Hotel hotel);
        bool CreateRoom(String hotelId, HotelRoom room);
        bool CreateImage(String hotelId, HotelImage Image);

    }
}
