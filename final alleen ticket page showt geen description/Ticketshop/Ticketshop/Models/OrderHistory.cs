using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ticketshop.Models
{
    public class OrderHistory
    {
        [Key]
        public int PrimaryKey { get; set; }
        public string CustomerEmail { get; set; }
        public int EventID { get; set; }
    }
}