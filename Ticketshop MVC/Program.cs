using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Model;
namespace Ticketshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Sup fam!");
            //connect to database
            // using (var db = new TicketContext())
            // {
            //     Theater t = new Theater
            //     {
            //         Available_seats = 99,
            //         Theatername = "Pathe de Kuip",
            //         Theateradress = "Cor Kieboomplein 501, 3077 MK Rotterdam"
            //     };
            //     db.Theaters.Add(t);
            //     db.SaveChanges();
            // }
            Projection();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();

        static void Projection(){           
            using (var db = new TicketContext())
            {
                var test = from t in db.Theaters select t;
                foreach (var theater in test){
                    Console.WriteLine("- {0} | {1} | {2}", theater.Available_seats, theater.Theateradress, theater.Theatername);
                }
            }
            }
    }
}
