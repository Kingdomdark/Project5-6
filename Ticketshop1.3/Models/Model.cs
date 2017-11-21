using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Ticketshop.Models{
  public class TicketContext : DbContext {

     public DbSet<Customer> Customers { get; set; }
        public DbSet<Theater> Theaters{ get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<Order> Orders { get; set;}
      public TicketContext(DbContextOptions<TicketContext> options):base(options)
      {
          
      }
       
    }

    

    public class Theater {
        //[Key]
        public int TheaterID { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public int Available_seats { get; set; }
    }
    
    public class Order {
        //[Key]
        public int OrderID { get; set;}
        //[ForeignKey]
        public virtual Customer CustomerID{ get; set;}
        //[ForeignKey]
        public virtual Ticket TicketID {get; set;}
    }
}