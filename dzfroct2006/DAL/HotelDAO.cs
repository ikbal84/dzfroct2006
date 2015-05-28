using dzfroct2006.Models;
using dzfroct2006.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.DAL
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
            catch (Exception ex)
            {
                return false;
            }
            
        }


        public bool CreateRoom(String hotelId, HotelRooms room)
        {
            try
            {
                var context = new HotelsDBContext();

                long ParentHotelID = Int32.Parse(hotelId);

                var hotel = context.Hotels.Where(h=> h.HotelID == ParentHotelID).First();
                hotel.Rooms.Add(room);

                context.Rooms.Add(room);
                context.Hotels.Add(hotel);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public bool CreateImage(String hotelId, HotelImages Image)
        {
            try
            {
                var context = new HotelsDBContext();

                long ParentHotelID = Int32.Parse(hotelId);

                var hotel = context.Hotels.Where(h=> h.HotelID == ParentHotelID).First();
                hotel.HotelImages.Add(Image);

                context.HotelImages.Add(Image);
                context.Hotels.Add(hotel);

                context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

    }
}