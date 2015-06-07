using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Data.Model
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdCommune { get; set; }

        public long CodePostal { get; set; }

        public string Commune { get; set; }
        public string Wilaya { get; set; }
    }

}