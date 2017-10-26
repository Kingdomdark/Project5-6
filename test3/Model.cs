using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model{
  public class TicketContext : DbContext {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Theater> Theaters{ get; set; }
        public DbSet<Ticket> Tickets{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
          optionsBuilder.UseSqlite("Data Source=Webshop.db");
        }
    }

    public class Customer {
        //[Key]
        public int CustomerID { get; set; }
        public string Username { get; set; }
        public string Userlastname{ get; set; }
        //[MaxLength(50)]
        public string email_adress{ get; set;}
        //[MaxLength(24)]
        public string _password{ get; set;}
    }

    public class Theater {
        //[Key]
        public int TheaterID { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public int Available_seats { get; set; }
    }
    public class Ticket {
        //[Key]
        public int TicketID { get; set;}
        public float Price { get; set;}
        public string Eventname { get; set;}
        public string Genre { get; set;}
        public DateTime DateTime { get; set;}
        //[ForeignKey]
        public virtual Theater TheaterID { get; set;}
    } 
}