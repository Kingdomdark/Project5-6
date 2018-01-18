using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models.OrderHistoryViewModels
{
    public class IndexViewModel
    {
        public int EventID { get; set; }
        public float Price { get; set; }
        public string Eventname { get; set; }
        public string Genre { get; set; }
        public DateTime DateAndTime { get; set; }
        public int AvailableTickets { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public string EventType { get; set; }
    }
}