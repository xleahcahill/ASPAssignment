using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyConcert.Models
{
    public class Venue
    {
        public virtual ICollection<Show> shows { get; set; }
        [Key]
        public String VenueId { get; set; }

        [Required, StringLength(30)]
        public String VenueName { get; set; }

        [Required, StringLength(30)]
        public String City { get; set; }

        [Required]
        public int Capacity { get; set; }
    }
}