using Hotels.Data.Model;
using Hotels.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hotels.Data.Services
{
    public class HotelDAO : IHotelDAO
    {
        public bool CreateHotel(Hotel hotel)
        {
            try
            {
                var context = new HotelsDBContext();

                context.Hotels.Add(hotel);

                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }


        public bool CreateRoom(String hotelId, HotelRoom room)
        {
            try
            {
                var context = new HotelsDBContext();

                long ParentHotelID = Int32.Parse(hotelId);

                var hotel = context.Hotels.Where(h=> h.HotelID == ParentHotelID).FirstOrDefault();
                hotel.Rooms.Add(room);

                context.Rooms.Add(room);
                context.Hotels.Add(hotel);

                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }


        public bool CreateImage(String hotelId, HotelImage Image)
        {
            try
            {
                var context = new HotelsDBContext();

                long ParentHotelID = Int32.Parse(hotelId);

                var hotel = context.Hotels.Where(h=> h.HotelID == ParentHotelID).FirstOrDefault();
                hotel.HotelImages.Add(Image);

                context.HotelImages.Add(Image);
                context.Hotels.Add(hotel);

                context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

    }
}