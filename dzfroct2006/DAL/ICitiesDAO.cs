using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzfroct2006.DAL
{
    interface ICitiesDAO
    {
        List<City> getAllCities();
        List<City> citiesStartWith(string searchedCity);
    }
}
