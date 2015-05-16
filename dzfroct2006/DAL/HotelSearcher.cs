using dzfroct2006.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace dzfroct2006.DAL
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
        public Tuple<List<Hotels>, int> Search( String SearchedTown, String SearchedWilaya, int SearchedNbPersonnes = 0, 
                                                String SortProperty = "name", String SortType = "asc", int PageNumber = 1, 
                                                int PageSize = -1)
        {
            
            PageSize = (PageSize == -1) ? Int32.Parse(WebConfigurationManager.AppSettings["PageSize"].ToString()) : PageSize;
            
            //seraching for City and NbPersonnes
            IQueryable<Hotels> HotelsQuery = context.Hotels;
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
            HotelsQuery = HotelsQuery.Skip((PageNumber - 1) * PageSize).Take(PageSize);

            return Tuple.Create(HotelsQuery.ToList(),countAllResults);
        }

        private IQueryable<Hotels> Sort(IQueryable<Hotels> query, String SortProperty, String SortType)
        {
            switch(SortProperty)
            {
                case "name": query = (String.Equals(SortType, "asc")) ? query.OrderBy(h => h.Name): query.OrderByDescending(h => h.Name);
                            break;

                case "stars": query = (String.Equals(SortType, "asc")) ? query.OrderBy(h => h.NbStars) : query.OrderByDescending(h => h.NbStars);
                            break;

                default: query = (String.Equals(SortType, "asc")) ? query.OrderBy(h => h.Name) : query.OrderByDescending(h => h.Name);
                            break;
            }

            return query;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchedCity"></param>
        /// <param name="SearchedFeatures"></param>
        /// <param name="SearchedNbPersonnes"></param>
        /// <returns></returns>
        public Tuple<List<Hotels>, int> Search(String SearchedTown, String SearchedWilaya, List<String> SearchedFeatures, int SearchedNbPersonnes = 0)
        {
            //seraching for City and NbPersonnes
            var hotlemmm = context.Hotels.ToList();
            IQueryable<Hotels> HotelsQuery = context.Hotels;
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
            this.Dispose();
        }

    }
}