using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyConcert.Models
{
    public class Booking
    {
        public virtual ICollection<BookingTicket> bookingTicket { get; set; }

        public IEnumerable<TicketDetails> TicketTypes { get; set; }

        [Key]
        public int BookingNo { get; set; }

        [Required]
        public string CustomerId { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [StringLength(50)]
        public string BillingAddress { get; set; }

        [StringLength(30)]
        public string BillingCity { get; set; }

        [StringLength(8)]
        public string BillingPostcode { get; set; }

        [Required, StringLength(50)]
        public string PaymentDetails { get; set; }
        public int ShowId { get; set; }
    }
}