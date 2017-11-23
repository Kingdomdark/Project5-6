using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Ticketshop.Models;

    public class OrderViewModel {
        //[Key]
        public int OrderID { get; set;}
        //[ForeignKey]
        public virtual Customer CustomerID{ get; set;}
        //[ForeignKey]
        public virtual Ticket TicketID {get; set;}
    }