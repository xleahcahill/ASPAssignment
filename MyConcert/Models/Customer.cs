using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyConcert.Models
{
    public class Customer
    {
        [Key, ForeignKey("User")]
        public String CustomerId { get; set; }

        [StringLength(30)]
        public String FirstName { get; set; }

         [StringLength(30)]
        public String Surname { get; set; }

       
        [Required(ErrorMessage = "The date of birth is required and must be a valid date.")]
        [DataType(DataType.Date)]
        [Display(Name = "DOB")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [Required, StringLength(50)]
        public String Address { get; set; }

        [StringLength(20)]
        [Display(Name = "Display name")]
        public string DisplayName { get; set; }



        [Required, StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 2)]
        public String City { get; set; }

        [Required, StringLength(8, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Postcode")]
        public String Postcode { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}