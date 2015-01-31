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

        public DbSet<Hotels> Hotels { get; set; }
        public DbSet<HotelOwners> Owner { get; set; }
        public DbSet<HotelRooms> Rooms { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<HotelFeatures> HotelFeatures { get; set; }
        public DbSet<HotelImages> HotelImages { get; set; }
    }
}