using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyConcert.Models
{
    public class TicketDetails
    {
        public virtual ICollection<BookingTicket> bookingTicket { get; set; }

        [Key]
        public int TicketId { get; set; }

        public double VIPTicketExtraPrice { get; set; }

        public double TieredSeatingExtraTicketPrice { get; set; }

        [Required]
        public double StandardTicketPrice { get; set; }

        public double FrontRowSeatingExtraPrice { get; set; }

        public string name { get; set; }


        [StringLength(30)]
        public string TicketDescription { get; set; }

     
    }
}
