using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyConcert.Models
{
    public class Show
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: dddd, dd/ MMMM/ yyyy}")]
        public DateTime ShowDate { get; set; }

        [Required]
        public String VenueId { get; set; }

        [Required, StringLength(20)]
        public String ShowTitle { get; set; }

        [Required, StringLength(20)]
        public String ArtistId { get; set; }

        [Required, StringLength(20)]
        public String ArtistName { get; set; }

        [Required, EnumDataType(typeof(SeatingTypes))]
        public SeatingTypes SeatingTypes { get; set; }

        public virtual ICollection<Booking> booking { get; set; }

        [StringLength(100)]
        public string Conimage { get; set; }

        [StringLength(100)]
        public string stageimage { get; set; }

        public virtual ICollection<ShowDetails> ShowDetails { get; set; }
    }
}