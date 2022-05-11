using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmailSender.Models.Domains
{
    public class Address
    {

        public Address()
        {
            Users = new Collection<ApplicationUser>();
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string Street { get; set; }

        [Required]
        [Display(Name = "Numer")]
        public string Number { get; set; }

        [Required]
        [Display(Name = "Miejscowość")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Kod pocztowy")]
        public string PostalCode { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }

    }
}