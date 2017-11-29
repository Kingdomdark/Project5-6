using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ticketshop.Models;

namespace Ticketshop.ViewModel
{
    public class EventViewModel
    {
        public IQueryable TicketInfo { get; set; }
        public string Eventname { get; set; }
    }
}
