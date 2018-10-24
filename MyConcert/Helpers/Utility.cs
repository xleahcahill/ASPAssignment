using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyConcert.Models;
using MyConcert.ViewModels;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MyConcert.Helpers
{
    public class Utility
    {
        private ApplicationDbContext db = new ApplicationDbContext(); //connection to database

        public IEnumerable<SelectListItem> GetQuantities(int startNum, int count)
        {
            var quantities = Enumerable.Range(startNum, count);
            var quantitySelectItems = quantities.Select(n => new SelectListItem
            {
                Value = n.ToString(),
                Text = n.ToString(), //text 
                Selected = (n == 0) //default

            });
            return quantitySelectItems;
        }

        public IEnumerable<TicketDetails> GetShowTicketTypes()
        {
            var ticketTypes = db.DetailsOfTicket;
            return ticketTypes;
        }

        public double GetTicketPrice(Show shows, TicketDetails ticketType )
        {
            double ticketPrice = ticketType.StandardTicketPrice;

            if (shows.SeatingTypes == SeatingTypes.VIPTicket)
            {
                ticketPrice += ticketType.VIPTicketExtraPrice;
            }

           if
            (shows.SeatingTypes == SeatingTypes.TieredSeatingTicket)
            {
                ticketPrice += ticketType.TieredSeatingExtraTicketPrice;
            }
            if 
                (shows.SeatingTypes == SeatingTypes.FrontRowSeating)
            {
                ticketPrice += ticketType.FrontRowSeatingExtraPrice;
            }
            return ticketPrice;
        }



        public BookingViewModel GetBookingViewModel(Show show)
        {
            //Show Show = db.Shows.Find(show); //Retrieving the concert for booking
            var ticketTypes = GetShowTicketTypes();

            List <BookingTicket> bookingTickets = new List<BookingTicket>();
            foreach (TicketDetails ticketType in ticketTypes)
            {
                bookingTickets.Add(new BookingTicket
                {
                    TicketId = ticketType.TicketId,
                    Price = GetTicketPrice(show, ticketType),
                    Quantity = 0
                });
            }

            string userId = HttpContext.Current.User.Identity.GetUserId();

    
            ApplicationUser currentUser = db.Users.Find(userId);        
            BookingViewModel bookingVM = new BookingViewModel()
            {
                Show = show,
                ShowDate = show.ShowDate,
                Booking = new Booking()
                {
                    ShowId = show.ShowId,
                    bookingTicket = bookingTickets,
                    CustomerId = "0",
                    Email = currentUser.Email,
                    BillingAddress = currentUser.Customer.Address,
                    BillingCity = currentUser.Customer.City,
                    BillingPostcode = currentUser.Customer.Postcode

                },
                TicketTypes = ticketTypes,
                Quantities = GetQuantities(0, 10)
            };

            return bookingVM;
        }
    }


        }