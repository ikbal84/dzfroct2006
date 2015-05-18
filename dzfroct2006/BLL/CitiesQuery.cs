using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace dzfroct2006.BLL
{
    public class CitiesQuery
    {


        public String GetListCities(String SearchName)
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


        private String ConvertCitiesListtoString(List<City> Cities)
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