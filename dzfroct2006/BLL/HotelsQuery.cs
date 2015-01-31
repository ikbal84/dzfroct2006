using dzfroct2006.DAL;
using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dzfroct2006.BLL
{
    public class HotelsQuery
    {
        public String City { get; set; }
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

            this.ResultHotels = HotelSearcher.Search(this.City, this.NbPersonnes);

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

            this.ResultHotels = HotelSearcher.Search(this.City, FilteredFeatures, this.NbPersonnes);

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

        /*public HotelsQuery filterResult()
        {
            var SelectedFeatures = this.Features.Where( f => !String.IsNullOrEmpty(f.SearchFeatureValue)).ToList();

            var FilteredHotels = new List<Hotels>();

            foreach (var hotel in this.ResultHotels)
            {
                bool isSatifyingFilter = true;

                foreach (var feature in SelectedFeatures)
                {
                    if (String.IsNullOrEmpty(feature.SearchFeatureValue))
                    {
                        continue;
                    }

                    foreach(var hotelFeature in hotel.HotelFeatures)
                    {
                        if (hotelFeature.Feature.FeatureName != feature.SearchFeatureName)
                        {
                            isSatifyingFilter = false;
                            break;
                        }
 
                    }

                    if (!isSatifyingFilter)
                        break;

                }

                if (isSatifyingFilter)
                {
                    FilteredHotels.Add(hotel);
                }
            }
            return this;
        }*/

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

    } 
}