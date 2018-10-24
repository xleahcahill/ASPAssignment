using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyConcert.Models
{
    public class BookingTicket
    {
        [Key]
        [Column(Order = 1)]
        public int BookingNo { get; set; }

        [Key]
        [Column(Order = 2)]
        public int TicketId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
    }
}