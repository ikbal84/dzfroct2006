using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Hotels.Data.Model;

namespace Hotels.Data.Services
{
    public class HotelsDBInitializer : DropCreateDatabaseIfModelChanges<HotelsDBContext>
    {
        protected override void Seed(HotelsDBContext context)
        {
            // Initialiser chargement codes communes 
            CitiesDAO cities = new CitiesDAO();
            cities.InsertCitiesDB();

            /*
             *  
             * ['Bondi Beach', -33.890542, 151.274856, 4],
             * ['Coogee Beach', -33.923036, 151.259052, 5],
             * ['Cronulla Beach', -34.028249, 151.157507, 3],
             * ['Manly Beach', -33.80010128657071, 151.28747820854187, 2],
             * ['Maroubra Beach', -33.950198, 151.259302, 1]
             */

            //Features : global for all hotels
            #region Features_declaration
            var Features1 = new Features() { FeatureName = "Wifi", FeatureDescription = "Wifi dans la chambre", isPrincipale = true };

            var Features2 = new Features() { FeatureName = "Petit déjeuné", FeatureDescription = "Petit déjeuné en salle", isPrincipale = true };

            var Features3 = new Features() { FeatureName = "Télé", FeatureDescription = "Télévision avec 150 chaines", isPrincipale = true };

            var Features4 = new Features() { FeatureName = "Parking", FeatureDescription = "570 places", isPrincipale = false };

            var Features5 = new Features() { FeatureName = "Piscine", FeatureDescription = "Superbe piscine", isPrincipale = false };

            context.Features.Add(Features1);
            context.Features.Add(Features2);
            context.Features.Add(Features3);
            context.Features.Add(Features4);
            context.Features.Add(Features5);
            #endregion

            // Hotel 1 
            #region Hotel_Anissov
            var hotel = new Hotel()
            {
                Name = "Hotel Anissov",
                Description = "Un simple hotel de test",
                FaxNumber1 = "0021321659878",
                NbStars = 3,
                Town = "Aintork",
                Wilaya = "Oran",
                GeoHotel = new GeoHotel { InfoMapHotel = "Wahran Hotel", LatitudeHotel = 35.702441, LongitudeHotel = -0.646563, AltitudeHotel = 1 },

            };


            var Room = new HotelRoom() { RoomType = "Double", Description = "chambre hayla", Hotel = hotel, NbPersonnes = 2, NbRooms = 5 };

            var HotelFeatures1 = new HotelFeature() { Feature = Features1, Hotel = hotel, Price = 1 };
            var HotelFeatures2 = new HotelFeature() { Feature = Features2, Hotel = hotel, Price = 2 };

            context.Hotels.Add(hotel);
            context.Rooms.Add(Room);

            context.HotelFeatures.Add(HotelFeatures1);
            context.HotelFeatures.Add(HotelFeatures2);
            #endregion

            //Hotel 2
            #region Hotel_Nadirov
            var hotel2 = new Hotel()
            {
                Name = "Hotel Nadirov",
                Description = "Un simple hotel de test",
                FaxNumber1 = "0021321659878",
                NbStars = 1,
                Town = "Ain touta",
                Wilaya = "Batna",
                GeoHotel = new GeoHotel { InfoMapHotel = "Batna Hotel", LatitudeHotel = 35.551357, LongitudeHotel = 6.178383, AltitudeHotel = 1 },
            };

            var Room2 = new HotelRoom() { RoomType = "GuissGuiss", Description = "chambre hayla", Hotel = hotel2, NbPersonnes = 4, NbRooms = 5 };


            var HotelFeatures2_1 = new HotelFeature() { Feature = Features1, Hotel = hotel2, Price = 12 };

            context.Hotels.Add(hotel2);
            context.Rooms.Add(Room2);

            context.HotelFeatures.Add(HotelFeatures2_1);
            #endregion

            //Hotel3
            #region Hotel_Ikbal
            var hotel3 = new Hotel()
            {
                Name = "Hotel Ikbal",
                Description = "Un simple hotel de test",
                FaxNumber1 = "0021321659878",
                NbStars = 5,
                Town = "Dar el Beida",
                Wilaya = "Alger",
                GeoHotel = new GeoHotel { InfoMapHotel = "Alger Hotel", LatitudeHotel = 36.709825, LongitudeHotel = 3.210534, AltitudeHotel = 1 },
            };

            var Room3 = new HotelRoom() { RoomType = "Luxe", Description = "chambre Extra", Hotel = hotel3, NbPersonnes = 4, NbRooms = 5 };


            var HotelFeatures3_1 = new HotelFeature() { Feature = Features1, Hotel = hotel3, Price = 1 };
            var HotelFeatures3_2 = new HotelFeature() { Feature = Features2, Hotel = hotel3, Price = 2 };
            var HotelFeatures3_3 = new HotelFeature() { Feature = Features3, Hotel = hotel3, Price = 2 };

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