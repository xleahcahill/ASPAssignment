using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyConcert.Models
{
    public class ShowDetails
    {
        [Key]
        public int ShowDetailsId { get; set; }

        [StringLength(30), Required]
        public String Genre { get; set; }

        [Required, StringLength(30)]
        public String VenueName { get; set; }

        [Required]
        public String VenueId { get; set; }

        [Required]
        public DateTime ShowDate { get; set; }

        [Required]
        public DateTime ShowStartTime { get; set; }

        [Required]
        public DateTime ShowEndTime { get; set; }

        [Required]

        [StringLength(1000)]
        public string Summary { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public bool IsVIPAvailable { get; set; }
        public bool IsFrontRowAvailable { get; set; }

        public bool IsTieredSeatingAvailable { get; set; }
        public string ArtistName { get; set; }

    }
}