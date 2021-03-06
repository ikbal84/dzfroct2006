﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Hotels.Data.Model;

namespace Hotels.Data.Services
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

        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<HotelOwner> Owner { get; set; }
        public virtual DbSet<HotelRoom> Rooms { get; set; }
        public virtual DbSet<Features> Features { get; set; }
        public virtual DbSet<HotelFeature> HotelFeatures { get; set; }
        public virtual DbSet<HotelImage> HotelImages { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<GeoHotel> GeoHotel { get; set; }
        public virtual DbSet<Visitor> Visitor { get; set; }
    }
}