using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Hotels.Data.Services;
using Hotels.Data.Model;

namespace Hotels.Business
{
    public class HotelsQuery
    {
        public String Town { get; set; }
        public String Wilaya { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NbPersonnes { get; set; }
        public int NbRooms { get; set; }
        public String SortProperty { get; set; }
        public String SortType { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalResultCount { get; set; }
        public bool PaginationEnabled { get; set; }

        public List<SearchFeatures> Features { get; set; }

        public List<Hotel> ResultHotels { get; set; }

        public HotelsQuery() 
        {
            this.ResultHotels = new List<Hotel>();
            this.Features = new List<SearchFeatures>();
            this.PageSize = Int32.Parse(WebConfigurationManager.AppSettings["PageSize"].ToString());
            this.IntiFeatures();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HotelsQuery GetHotelsFromHome()
        {
            HotelSearcher HotelSearcher = new HotelSearcher();

            Tuple<List<Hotel>, int> Result = HotelSearcher.Search(this.Town, this.Wilaya, this.NbPersonnes);

            this.ResultHotels = Result.Item1;
            
            UpdatePagination(Result.Item2);
            
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HotelsQuery MakeNewSearch()
        {
            this.ResultHotels = new List<Hotel>();

            var FilteredFeatures = this.GetOnlyAskedFeatures();

            HotelSearcher HotelSearcher = new HotelSearcher();

            Tuple<List<Hotel>, int> Result = HotelSearcher.Search(this.Town, this.Wilaya, FilteredFeatures, this.NbPersonnes);

            this.ResultHotels = Result.Item1;
            
            UpdatePagination(Result.Item2);

            return this;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public HotelsQuery SortResults()
        {
            this.ResultHotels = new List<Hotel>();
            HotelSearcher HotelSearcher = new HotelSearcher();
            Tuple<List<Hotel>, int> SortResult =  HotelSearcher.Search(this.Town, this.Wilaya, this.NbPersonnes, this.SortProperty, this.SortType);

            this.ResultHotels = SortResult.Item1;
            UpdatePagination(SortResult.Item2);

            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<String> GetOnlyAskedFeatures()
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

            FeaturesDAO features = new FeaturesDAO();

            List<SearchFeatures> SearchFeatures = new List<SearchFeatures>();
            foreach (var feature in features.GetAllFeatures())
            {
                SearchFeatures.Add(new SearchFeatures() 
                                            { 
                                               SearchFeatureName = feature.FeatureName, 
                                               SearchFeatureValue = String.Empty ,
                                               isPrincipale = feature.isPrincipale
                                            });

            }

            this.Features = SearchFeatures;
        }

        public HotelsQuery GetPage(int PageNumber)
        {
            this.Page = PageNumber;

            this.ResultHotels = new List<Hotel>();
            HotelSearcher HotelSearcher = new HotelSearcher();
            Tuple<List<Hotel>, int> Result = HotelSearcher.Search(this.Town, this.Wilaya, this.NbPersonnes, this.SortProperty, this.SortType, this.Page);

            this.ResultHotels = Result.Item1;
            
            UpdatePagination(Result.Item2);
            return this;

        }

        private void UpdatePagination(int TotalCount)
        {
            this.TotalResultCount = TotalCount;
            this.PaginationEnabled = ((float)this.TotalResultCount / this.PageSize > 1) ? true : false;
        }

    } 
}