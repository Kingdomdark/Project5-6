using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models
{
    public class Order
    {
        //[Key]
        public int OrderID { get; set; }
        //[ForeignKey]
        public virtual ApplicationUser CustomerID { get; set; }
        //[ForeignKey]
        public virtual Ticket TicketID { get; set; }
    }
}
