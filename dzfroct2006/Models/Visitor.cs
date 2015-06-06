using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace dzfroct2006.Models
{
    public class Visitor
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }

        [Required]
        public String UserName { get; set; }

        public String LastName { get; set; }
        public String FirstName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
                
        public String Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public bool Valid { get; set; }

        public String ValidationToken { get; set; }

    }
}