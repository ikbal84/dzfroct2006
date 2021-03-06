﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotels.Data.Model
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long HotelID { get; set; }
        
        [Required]
        public String Name {get; set;}
        
        [Required]
        public String Description {get; set;}

        [DefaultValue(1)]
        
        public int NbStars { get; set; }


        public String PhoneNumber1 {get; set;}
        public String PhoneNumber2 { get; set; }
        public String PhoneNumber3 { get; set; }

        public String FaxNumber1 {get; set;}
        public String FaxNumber2 { get; set; }
        public String FaxNumber3 { get; set; }

        public String Email1 { get; set; }
        public String Email2 { get; set; }

        public String Address { get; set; }
        public String Town { get; set; }
        public String Wilaya { get; set; }
        public String AddressDescription { get; set; }

        public virtual HotelOwner Owner { get; set; }

        public virtual List<HotelRoom> Rooms { get; set; }

        public virtual List<HotelFeature> HotelFeatures { get; set; }

        public virtual List<HotelImage> HotelImages { get; set; }

        public virtual GeoHotel GeoHotel { get; set;}
     }
}