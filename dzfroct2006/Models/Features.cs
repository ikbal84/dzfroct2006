using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dzfroct2006.Models
{
    public class Features
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long FeatureID { get; set; }

        public String FeatureName { get; set; }

        public String FeatureDescription { get; set; }
    }
}