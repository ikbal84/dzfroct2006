using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hotels.Data.Model
{
    public class HotelRoom
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long RoomID { get; set; }

        public String RoomType { get; set; }

        public String Description { get; set; }

        public int NbPersonnes { get; set; }

        public int NbRooms { get; set; }

        public String Price { get; set; }

        public virtual Hotel Hotel { get; set; }

    }
}