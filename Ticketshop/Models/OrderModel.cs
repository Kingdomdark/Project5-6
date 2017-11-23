using System;

namespace Ticketshop.Models
{
    public class Order {
        //[Key]
        public int OrderID { get; set;}
        //[ForeignKey]
        public virtual Customer CustomerID{ get; set;}
        //[ForeignKey]
        public virtual Ticket TicketID {get; set;}
    }
}