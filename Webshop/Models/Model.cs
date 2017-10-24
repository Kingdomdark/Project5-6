using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Model
{
    //[(typeof(UserMetadata))]
    // public partial class User
    // {
    //     public string ConfirmPassword{ get; set;}
    // }
    public class TicketContext : DbContext 
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Theater> Theaters{ get; set; }
        public DbSet<Ticket> Tickets{ get; set; }
        public DbSet<Customer> userAccount { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
          optionsBuilder.UseNpgsql("User ID=postgres;Password=;Host=localhost;Port=5432;Database=Ticketshop;Pooling=true;");
        }
    }

    public class Customer {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Username is required.")]
        [MaxLength(24)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Last Name is required.")]
        [MaxLength(24)]
        public string Userlastname{ get; set; }
        [Required(ErrorMessage = "Email is required.")]
        [MaxLength(50)]
        [RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Please enter a valid email.")]
        public string email_adress{ get; set;}
        [Required(ErrorMessage = "Password is required.")]
        [MinLength(6)]
        [DataType(DataType.Password)]
        public string _password{ get; set;}
        [Compare("Password", ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword{ get; set; }
    }

    public class Theater {
        [Key]
        public int TheaterID { get; set; }
        public string Theatername { get; set; }
        public string Theateradress { get; set; }
        public int Available_seats { get; set; }
    }
    public class Ticket {
        [Key]
        public int TicketID { get; set;}
        public float Price { get; set;}
        public string Eventname { get; set;}
        public string Genre { get; set;}
         //[ForeignKey]
        public DateTime DateTime { get; set;}
        public int TheaterID { get; set;}
    } 
    // public class UserMetadata
    // {
    //     [Display(Name = "Username")]
    //     [Required(AllowEmptyStrings = false, ErrorMessage = "Username is required")]
    //     public string Username { get; set; }

    //     [Display(Name = "Last name")]
    //     [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is required")]
    //     public string Userlastname { get; set; }

    //     [Display(Name = "Email address")]
    //     [Required(AllowEmptyStrings = false, ErrorMessage = "Email address is required")]
    //     [DataType(DataType.EmailAddress)]
    //     public string email_adress { get; set; }
        
    //     [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
    //     [DataType(DataType.Password)]
    //     [MinLength(6, ErrorMessage = "The password needs a minimum of 6 characters")]
    //     public string _Password { get; set;}

    //     [Display(Name = "Confirm Password")]
    //     [DataType(DataType.Password)]
    //     [Compare("Password", ErrorMessage = "The password does not match")]
    //     public string ConfirmPassword { get; set; }
    // }
}