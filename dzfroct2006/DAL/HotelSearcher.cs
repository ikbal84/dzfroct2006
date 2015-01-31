using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.DAL
{
    public class HotelSearcher
    {
        private HotelsDBContext context;

        public HotelSearcher()
        {
            context = new HotelsDBContext();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchedCity"></param>
        /// <param name="SearchedNbPersonnes"></param>
        /// <returns></returns>
        public List<Hotels> Search(String SearchedCity, int SearchedNbPersonnes = 0)
        {
            //seraching for City and NbPersonnes
            IQueryable<Hotels> HotelsQuery = context.Hotels;
            if (!String.IsNullOrEmpty(SearchedCity))
            {
                HotelsQuery = HotelsQuery.Where(h => h.Town.ToLower().Contains(SearchedCity.ToLower()));
            }

            if (SearchedNbPersonnes != 0)
            {
                HotelsQuery = HotelsQuery.Where(h => h.Rooms.Any(r => r.NbPersonnes >= SearchedNbPersonnes));
            }
            
            return HotelsQuery.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchedCity"></param>
        /// <param name="SearchedFeatures"></param>
        /// <param name="SearchedNbPersonnes"></param>
        /// <returns></returns>
        public List<Hotels> Search(String SearchedCity, List<String> SearchedFeatures, int SearchedNbPersonnes = 0)
        {
            //seraching for City and NbPersonnes
            var hotlemmm = context.Hotels.ToList();
            IQueryable<Hotels> HotelsQuery = context.Hotels;
            if (!String.IsNullOrEmpty(SearchedCity))
            {
                HotelsQuery = HotelsQuery.Where( h => h.Town.ToLower().Contains(SearchedCity.ToLower()));
            }
            
            if (SearchedNbPersonnes != 0)
            {
                HotelsQuery = HotelsQuery.Where(h => h.Rooms.Any(r => r.NbPersonnes >= SearchedNbPersonnes));
            }
                                         
            //seraching for features
            if (SearchedFeatures.Count() != 0)
            {
                foreach (var feature in SearchedFeatures)
                {
                    HotelsQuery = HotelsQuery.Where(h => h.HotelFeatures.Any(hf => hf.Feature.FeatureName.Equals(feature)));
                }
            }

            return HotelsQuery.ToList();
        }
    }
}