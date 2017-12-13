using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models
{
    public class Event
    {
        [Key]
        public int EventID { get; set; }
        public float Price { get; set; }
        [StringLength(50)]
        public string Eventname { get; set; }
        public string Genre { get; set; }
        public DateTime DateAndTime { get; set; }
        public int AvailableTickets { get; set; }
        [StringLength(35)]
        public string Theatername { get; set; }
        [StringLength(50)]
        public string Theateradress { get; set; }
        [StringLength(30)]
        public string EventType { get; set; }
    }
}
