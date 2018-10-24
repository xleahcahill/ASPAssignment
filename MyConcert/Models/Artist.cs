using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyConcert.Models
{
    public class Artist
    {
        [Key]
        public String ArtistID { get; set; }

        [Required, StringLength(30)]
        public string ArtistName { get; set; }

        [StringLength(30), Required]
        public String Genre { get; set; }
    }
}
