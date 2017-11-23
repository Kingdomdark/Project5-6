using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ticketshop.Models;

public class TicketViewModel {
        //[Key]
        public int TicketID { get; set;}
        public float Price { get; set;}
        public string Eventname { get; set;}
        public string Genre { get; set;}
        public DateTime DateTime { get; set;}
        //[ForeignKey]
        public virtual Theater TheaterID { get; set;}
}
