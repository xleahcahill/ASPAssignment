
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyConcert.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyConcert.ViewModels
{
    public class BookingViewModel
    {
        public Show Show { get; set; }

        public Booking Booking { get; set; }

        public IEnumerable<System.Web.Mvc.SelectListItem> Quantities { get; set; }

        //dddd, dd / MMMM / yyyy
        [DisplayFormat(ApplyFormatInEditMode =true, DataFormatString ="{0: dddd, dd/ MMMM/ yyyy}")]
        public DateTime ShowDate { get; set; }


        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0: hh: mm}")]
        public DateTime ShowStartTime { get;set;}
        public IEnumerable<TicketDetails> TicketTypes { get; set; }

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