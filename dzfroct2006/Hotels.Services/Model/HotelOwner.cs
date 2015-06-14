using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotels.Data.Model
{
    public class HotelOwner
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OwnerID { get; set; }

        public String UserName {get; set;}
        public String LastName { get; set; }

        public String FirstName { get; set; }

        public String Address { get; set; }
        public String Town { get; set; }
        public String Wilaya { get; set; }
        public String AddressDescription { get; set; }

        public String PhoneNumber { get; set; }
        public String FaxNumber { get; set; }
        public String Email { get; set; }

        public bool Valid {get; set;}
        public string ValidationToken {get; set;}
        public DateTime CreationDate {get; set;}
        public DateTime LastUpdateDate {get; set;}
        public virtual List<Hotel> HotelsList { get; set; }
    }
}