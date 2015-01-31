using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dzfroct2006.Models
{
    public class HotelOwners
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long OwnerID { get; set; }

        public String Name { get; set; }

        public String Address { get; set; }
        public String Town { get; set; }
        public String Wilaya { get; set; }
        public String AddressDescription { get; set; }

        public String PhoneNumber { get; set; }
        public String FaxNumber { get; set; }
        public String Email { get; set; }

        public virtual List<Hotels> HotelsList { get; set; }

    }
}