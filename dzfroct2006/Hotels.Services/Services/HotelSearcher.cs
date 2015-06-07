using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using Hotels.Data.Model;

namespace Hotels.Data.Services
{
    public class HotelSearcher: IDisposable
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
        public Tuple<List<Hotel>, int> Search( String SearchedTown, String SearchedWilaya, int SearchedNbPersonnes = 0, 
                                                String SortProperty = "name", String SortType = "asc", int PageNumber = 1, 
                                                int PageSize = -1)
        {
            
            int DeterminedPageSize = (PageSize == -1) ? Int32.Parse(WebConfigurationManager.AppSettings["PageSize"].ToString()) : PageSize;
            
            //seraching for City and NbPersonnes
            IQueryable<Hotel> HotelsQuery = context.Hotels;
            if (!String.IsNullOrEmpty(SearchedTown))
            {
                HotelsQuery = HotelsQuery.Where(h => h.Town.ToLower().Contains(SearchedTown.ToLower())
                                                    | h.Wilaya.ToLower().Contains(SearchedWilaya.ToLower())
                                                    | SearchedTown.ToLower().Contains(h.Town.ToLower())
                                                    | SearchedWilaya.ToLower().Contains(h.Wilaya.ToLower())
                                                    );
            }

            if (SearchedNbPersonnes != 0)
            {
                HotelsQuery = HotelsQuery.Where(h => h.Rooms.Any(r => r.NbPersonnes >= SearchedNbPersonnes));
            }

            int countAllResults = HotelsQuery.Count();
            
            //sorting..
            HotelsQuery = Sort(HotelsQuery, SortProperty, SortType);
            
            //paginating
            HotelsQuery = HotelsQuery.Skip((PageNumber - 1) * DeterminedPageSize).Take(DeterminedPageSize);

            return Tuple.Create(HotelsQuery.ToList(),countAllResults);
        }

        private IQueryable<Hotel> Sort(IQueryable<Hotel> query, String SortProperty, String SortType)

        {
            IQueryable<Hotel> SortQuery = null;

            switch(SortProperty)
            {
                
                case "name" : 
                default:
                    SortQuery = (String.Equals(SortType, "asc")) ? query.OrderBy(h => h.Name) : query.OrderByDescending(h => h.Name);
                            break;

                case "stars": SortQuery = (String.Equals(SortType, "asc")) ? query.OrderBy(h => h.NbStars) : query.OrderByDescending(h => h.NbStars);
                            break;
            }

            return SortQuery;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchedCity"></param>
        /// <param name="SearchedFeatures"></param>
        /// <param name="SearchedNbPersonnes"></param>
        /// <returns></returns>
        public Tuple<List<Hotel>, int> Search(String SearchedTown, String SearchedWilaya, List<String> SearchedFeatures, int SearchedNbPersonnes = 0)
        {
            //seraching for City and NbPersonnes

            IQueryable<Hotel> HotelsQuery = context.Hotels;
            if (!String.IsNullOrEmpty(SearchedTown))
            {
                HotelsQuery = HotelsQuery.Where(h => h.Town.ToLower().Contains(SearchedTown.ToLower())
                                                    | h.Wilaya.ToLower().Contains(SearchedWilaya.ToLower())
                                                    | SearchedTown.ToLower().Contains(h.Town.ToLower())
                                                    | SearchedWilaya.ToLower().Contains(h.Wilaya.ToLower())
                                                    );
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

            return Tuple.Create(HotelsQuery.ToList(), HotelsQuery.Count());
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

    }
}