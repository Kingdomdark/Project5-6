using System;

namespace Ticketshop.Models
{
    public class Theater {
        //[Key]
        public int TheaterID { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public int Available_seats { get; set; }
    }
}