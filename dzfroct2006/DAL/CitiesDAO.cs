using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.DAL
{
    public class CitiesDAO
    {

      public void insertCitiesDB()
          
      {

          var context = new HotelsDBContext();

         
         
            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"d:\projets\2015\HotelOnLineAlgeria\dzfroct2006\dzfroct2006\App_GlobalResources\codes_communes.csv");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(';');
                City city = new City() { CodePostal = Int32.Parse(words[1]), Commune = words[2], Wilaya = words[0] };

                context.City.Add(city);
            }

            file.Close();
            context.SaveChanges();
        }

      public List<string> citiesStartWith(string searchedCity)
      {
          var context = new HotelsDBContext();
          IQueryable<City> citiesQuery = context.City;
          if (!String.IsNullOrEmpty(searchedCity))
          {
              citiesQuery = citiesQuery.Where(c => c.Commune.ToLower().Contains(searchedCity.ToLower())
                                                  | c.Wilaya.ToLower().Contains(searchedCity.ToLower()));
          }


         return citiesQuery.Select(c => c.Commune).ToList();
          //return citiesQuery.ToList();

         
      }
    }    
}