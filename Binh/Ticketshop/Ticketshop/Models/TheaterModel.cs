using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models
{
    public class Theater
    {
        public int TheaterID { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public int Available_seats { get; set; }
    }
}
