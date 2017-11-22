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
}