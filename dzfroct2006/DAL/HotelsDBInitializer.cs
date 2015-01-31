using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dzfroct2006.DAL
{
    public class HotelsDBInitializer: DropCreateDatabaseAlways<HotelsDBContext> //DropCreateDatabaseIfModelChanges<HotelsDBContext>
    {
        protected override void Seed(HotelsDBContext context)
        {
            //Features : global for all hotels
            #region Features_declaration
            var Features1 = new Features() { FeatureName = "Wifi", FeatureDescription = "Wifi dans la chambre" };

            var Features2 = new Features() { FeatureName = "Petit déjeuné", FeatureDescription = "Petit déjeuné en salle" };

            var Features3 = new Features() { FeatureName = "Télé", FeatureDescription = "Télévision avec 150 chaines" };

            context.Features.Add(Features1);
            context.Features.Add(Features2);
            context.Features.Add(Features3);
            #endregion

            // Hotel 1 
            #region Hotel_Anissov
            var hotel = new Hotels() { Name = "Hotel Anissov", Description = "Un simple hotel de test", FaxNumber1 = "0021321659878", NbStars = 3 };

            var Room = new HotelRooms() { RoomType = "Double", Description = "chambre hayla", Hotel = hotel, NbPersonnes = 2, NbRooms = 5 };

            var HotelFeatures1 = new HotelFeatures() { Feature = Features1, Hotel = hotel, Price = 1 };
            var HotelFeatures2 = new HotelFeatures() { Feature = Features2, Hotel = hotel, Price = 2 };

            context.Hotels.Add(hotel);
            context.Rooms.Add(Room);

            context.HotelFeatures.Add(HotelFeatures1);
            context.HotelFeatures.Add(HotelFeatures2);
            #endregion

            //Hotel 2
            #region Hotel_Nadirov
            var hotel2 = new Hotels() { Name = "Hotel Nadirov", Description = "Un simple hotel de test", FaxNumber1 = "0021321659878", NbStars = 1 };

            var Room2 = new HotelRooms() { RoomType = "GuissGuiss", Description = "chambre hayla", Hotel = hotel2, NbPersonnes = 4, NbRooms = 5 };


            var HotelFeatures2_1 = new HotelFeatures() { Feature = Features1, Hotel = hotel2, Price = 12 };

            context.Hotels.Add(hotel2);
            context.Rooms.Add(Room2);

            context.HotelFeatures.Add(HotelFeatures2_1);
            #endregion

            //Hotel3
            #region Hotel_Ikbal
            var hotel3 = new Hotels() { Name = "Hotel Ikbal", Description = "Un simple hotel de test", FaxNumber1 = "0021321659878", NbStars = 5 };

            var Room3 = new HotelRooms() { RoomType = "Luxe", Description = "chambre Extra", Hotel = hotel3, NbPersonnes = 4, NbRooms = 5 };


            var HotelFeatures3_1 = new HotelFeatures() { Feature = Features1, Hotel = hotel3, Price = 1 };
            var HotelFeatures3_2 = new HotelFeatures() { Feature = Features2, Hotel = hotel3, Price = 2 };
            var HotelFeatures3_3 = new HotelFeatures() { Feature = Features3, Hotel = hotel3, Price = 2 };

            context.Hotels.Add(hotel3);
            context.Rooms.Add(Room3);

            context.HotelFeatures.Add(HotelFeatures3_1);
            context.HotelFeatures.Add(HotelFeatures3_2);
            context.HotelFeatures.Add(HotelFeatures3_3);
            #endregion
            base.Seed(context);
        }
    }
}