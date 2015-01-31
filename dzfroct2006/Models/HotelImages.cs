using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dzfroct2006.Models
{
    public class HotelImages
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdImage { get; set; }

        public String FilePath { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public bool isMignature { get; set; }
        public bool isHeader { get; set; }
    }
}