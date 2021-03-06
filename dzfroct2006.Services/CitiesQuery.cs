﻿using Hotels.Data.Services;
using Hotels.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Hotels.Business
{
    public class CitiesQuery
    {


        public static String GetListCities(String SearchName)
        {
            CitiesDAO cityDAO = new CitiesDAO();
            List<City> Cities = null;

            if (String.IsNullOrEmpty(SearchName))
            {
                Cities = cityDAO.GetAllCities();
            }
            else
            {
                Cities = cityDAO.CitiesStartWith(SearchName);
            }

            return ConvertCitiesListtoString(Cities);
        }


        static String ConvertCitiesListtoString(List<City> Cities)
        {
            StringBuilder Result = new StringBuilder();

            foreach (var city in Cities)
            {
                if (Result.Length > 1)
                {
                    Result.Append(";");
                }

                Result.Append(city.Commune.Trim() +", " + city.Wilaya.Trim() +", "+ city.CodePostal);
            }

            return Result.ToString();
        }
    }
}