﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hotels.Data.Model;

namespace Hotels.Data.Services
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

      public void InsertCitiesDB() 
       {
            // Read the file and display it line by line.
            System.IO.StreamReader file =

            new System.IO.StreamReader(@"C:\Users\Moh\Documents\Visual Studio 2013\Projects\From Git\dzfroct2006\App_GlobalResources\codes_communes.csv");
            
            while (!file.EndOfStream)
            {
                string[] words = file.ReadLine().Split(';');
                City city = new City() { CodePostal = Int32.Parse(words[1]), Commune = words[2], Wilaya = words[0] };

                context.City.Add(city);
            }

            file.Close();
            context.SaveChanges();
        }


      public List<City> GetAllCities()
      {
          if (context.City != null)
              return context.City.OrderBy(c => c.CodePostal).ToList();
          else 
              return new List<City>();
      }


      public List<City> CitiesStartWith(string searchedCity)
      {


          if (!String.IsNullOrEmpty(searchedCity))
          {
              IQueryable<City> citiesQuery = context.City;
              citiesQuery = citiesQuery.Where(c => c.Commune.ToLower().StartsWith(searchedCity.ToLower())
                                                   || c.Wilaya.ToLower().StartsWith(searchedCity.ToLower()));
              return citiesQuery.OrderBy(c => c.CodePostal).ToList();

          }
          else
              return new List<City>();



      }

      public void Dispose()
      {
          this.context.Dispose();
      }
    }    
}