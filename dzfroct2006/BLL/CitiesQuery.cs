using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.BLL
{
    public class CitiesQuery
    {


        public List<string> getListCities(String SearchName, String SearchCodeValue)
        {
            CitiesDAO city = new CitiesDAO();
            return city.citiesStartWith(SearchName); ;
        }       
    }
}