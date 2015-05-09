using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.BLL
{
    public class HotelsQuery
<<<<<<< HEAD
    {
        public String Town { get; set; }
        public String Wilaya { get; set; }
=======
    {         
        public String City { get; set; }
>>>>>>> 7774f532c09ee5046e172ff015fc84abd9dbb377
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NbPersonnes { get; set; }
        public int NbRooms { get; set; }

        public List<SearchFeatures> Features { get; set; }

        public List<Hotels> ResultHotels { get; set; }
        
        private HotelsDBContext context;

        public HotelsQuery() {
            this.context = new HotelsDBContext();
            this.ResultHotels = new List<Hotels>();
            this.Features = new List<SearchFeatures>();
            
            this.IntiFeatures();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HotelsQuery getHotelsFromHome()
        {
            HotelSearcher HotelSearcher = new HotelSearcher();

            this.ResultHotels = HotelSearcher.Search(this.Town, this.Wilaya, this.NbPersonnes);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HotelsQuery makeNewSearch()
        {
            this.ResultHotels = new List<Hotels>();

            var FilteredFeatures = this.getOnlyAskedFeatures();

            HotelSearcher HotelSearcher = new HotelSearcher();

            this.ResultHotels = HotelSearcher.Search(this.Town, this.Wilaya, FilteredFeatures, this.NbPersonnes);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<String> getOnlyAskedFeatures()
        {
            List<String> filteredFeatures = new List<String>();

            foreach (var SearchFeature in this.Features)
            {
                if (!String.IsNullOrEmpty(SearchFeature.SearchFeatureValue))
                {
                    filteredFeatures.Add(SearchFeature.SearchFeatureName);
                }
            }

            return filteredFeatures;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public void IntiFeatures()
        {
            List<SearchFeatures> SearchFeatures = new List<SearchFeatures>();
            foreach (var feature in this.context.Features.ToList())
            {
                SearchFeatures.Add(new SearchFeatures() 
                                            { 
                                               SearchFeatureName = feature.FeatureName, 
                                               SearchFeatureValue = String.Empty 
                                            });

            }

            this.Features = SearchFeatures;
        }

        //detail horal
        public Hotels getHotel(long idHotel) {
          var  HotelQuery = from entity in context.Hotels where entity.HotelID == idHotel select entity;
          return HotelQuery.Single();
        }

    } 
}