using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.DAL
{
    public class CitiesDAO : ICitiesDAO, IDisposable
    {
        public HotelsDBContext context;
        
        public CitiesDAO(){
           this.context = new HotelsDBContext();
        }

        public CitiesDAO(HotelsDBContext _dbContext)
        {
            this.context = _dbContext;
        }

      public void insertCitiesDB() 
       {
          

            string line;

            // Read the file and display it line by line.
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"C:\Users\Moh\Documents\Visual Studio 2013\Projects\dzfroct2006\dzfroct2006\App_GlobalResources\codes_communes.csv");
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split(';');
                City city = new City() { CodePostal = Int32.Parse(words[1]), Commune = words[2], Wilaya = words[0] };

                context.City.Add(city);
            }

            file.Close();
            context.SaveChanges();
        }


      public List<City> getAllCities()
      {
          if (context.City != null)
              return context.City.OrderBy(c => c.Commune).ToList();
          else 
              return new List<City>();
      }


      public List<City> citiesStartWith(string searchedCity)
      {


          if (!String.IsNullOrEmpty(searchedCity))
          {
              IQueryable<City> citiesQuery = context.City;
              citiesQuery = citiesQuery.Where(c => c.Commune.ToLower().StartsWith(searchedCity.ToLower())
                                                   || c.Wilaya.ToLower().StartsWith(searchedCity.ToLower()));
              return citiesQuery.OrderBy(c => c.Commune).ToList();

          }
          else
              return new List<City>();



      }

      public void Dispose()
      {
          this.Dispose();
      }
    }    
}