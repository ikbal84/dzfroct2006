using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotels.Data.Model
{
    public class GeoHotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long IdGeoHotel { get; set; }

        public string InfoMapHotel { get; set; }
        public double LongitudeHotel { get; set; }
        public double LatitudeHotel { get; set; }
        public double AltitudeHotel { get; set; }
    }
}
