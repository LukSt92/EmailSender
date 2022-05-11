using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EmailSender.Models.Domains
{
    public class Message
    {

        public int Id { get; set; }

        [Required]
        [Display(Name = "Tytuł")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Treść Wiadomości")]
        public string MessageContent { get; set; }

        [Required]
        [Display(Name = "Odbiorca")]
        public string Receiver { get; set; }

        [Required]
        [Display(Name = "Nadawca")]
        public string Sender { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}