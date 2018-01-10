using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models
{
    public class Wishlist
    {
        [Key]
        public string CustomerEmail { get; set; }
        public List<Event> Events { get; set; }
    }
}
