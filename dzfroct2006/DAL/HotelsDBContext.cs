using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using dzfroct2006.Models;

namespace dzfroct2006.DAL
{
    public class HotelsDBContext : DbContext
    {
        public HotelsDBContext()
            : base("HotelsDB")
        {
            //Database.SetInitializer<HotelsDBContext>(new CreateDatabaseIfNotExists<HotelsDBContext>());      
            //Database.SetInitializer<HotelsDBContext>(new DropCreateDatabaseIfModelChanges<HotelsDBContext>());
            //Database.SetInitializer<HotelsDBContext>(new DropCreateDatabaseAlways<HotelsDBContext>());
           Database.SetInitializer<HotelsDBContext>(new HotelsDBInitializer());
        }

        public virtual DbSet<Hotels> Hotels { get; set; }
        public virtual DbSet<HotelOwners> Owner { get; set; }
        public virtual DbSet<HotelRooms> Rooms { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<HotelFeatures> HotelFeatures { get; set; }
        public virtual DbSet<HotelImages> HotelImages { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<GeoHotel> GeoHotel { get; set; }
    }
}