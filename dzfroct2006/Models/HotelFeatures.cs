using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dzfroct2006.Models
{
    public class HotelFeatures
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        public virtual Hotels Hotel { get; set; }

        public virtual Features Feature { get; set; }

        public double Price { get; set; }

    }
}