using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models
{
    public class Ticket
    {
        [Key]
        public int TicketID { get; set; }
        [Display(Name ="Prijs")]
        public float Price { get; set; }
        public string Eventname { get; set; }
        public string Genre { get; set; }
        public DateTime DateTime { get; set; }
        public Theater TheaterID { get; set; }
    }
}
